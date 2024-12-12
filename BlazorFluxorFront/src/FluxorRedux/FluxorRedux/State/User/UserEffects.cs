using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Fluxor;
using FluxorRedux.Models.Responses;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FluxorRedux.State.User
{
    public class UserEffects
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UserEffects> _logger;
        private readonly IDispatcher _dispatcher;

        public UserEffects(HttpClient httpClient, ILogger<UserEffects> logger, IDispatcher dispatcher)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        [EffectMethod]
        public async Task StoreUsersEffect(StoreUserAction action, IDispatcher dispatcher)
        {
            
            _dispatcher.Dispatch(new IsLoadingAction(true));
            
            try
            {
                var users = await _httpClient.GetFromJsonAsync<List<Models.User>>("api/User");
                
                _dispatcher.Dispatch(new StoreUserActionSuccess(users!));
            }
            catch (Exception e)
            {
                _dispatcher.Dispatch(new StoreUserActionFailure( $"something went wrong fetching users error : {e}" ));
                throw;
            }
        }
        
        [EffectMethod]
        public async Task DeleteUsersEffect(DeleteUserAction action, IDispatcher dispatcher)
        {
            
            // _dispatcher.Dispatch(new IsLoadingAction(true));
            
            try
            {
                var response = await _httpClient.DeleteAsync($"api/User?id={action.Id}");

                if (response.IsSuccessStatusCode)
                {

                    _dispatcher.Dispatch(new DeleteUserActionSuccess(action.Id));
                }
                else
                {
                    _dispatcher.Dispatch(new DeleteUserActionFailure( $"something went wron deleting user with id : {action.Id}" ));
                }
                
            }
            catch (Exception e)
            {
                _dispatcher.Dispatch(new DeleteUserActionFailure( $"something went wron deleting user with id : {action.Id}" ));
            }
        }
        
        [EffectMethod]
        public async Task CreateUsersEffect( CreateUserAction action, IDispatcher dispatcher)
        {
            var userStr = JsonSerializer.Serialize(action.User);
            var httpContent = new StringContent(userStr, Encoding.UTF8, "application/json");
            
            try
            {
                var response = await _httpClient.PostAsync("api/user", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    var baseResponse = JsonConvert.DeserializeObject<BaseResponse>(responseString);

                    if (baseResponse != null)
                    {

                        action.User.Id = baseResponse.ItemId;

                        _dispatcher.Dispatch(new CreateUserActionSuccess( action.User ));
                    }
                }
            }
            catch (Exception e)
            {
                _dispatcher.Dispatch(new CreateUserActionFailure( $"something went wron creating user with email : {action.User.Email}, error :{e}" ));
            }
        }
        
        [EffectMethod]
        public async Task CreateUpdateUsersEffect( UpdateUserAction action, IDispatcher dispatcher)
        {
            var userStr = JsonSerializer.Serialize(action.User);
            var httpContent = new StringContent(userStr, Encoding.UTF8, "application/json");
            
            try
            {
                var response = await _httpClient.PutAsync("api/user", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    var baseResponse = JsonConvert.DeserializeObject<BaseResponse>(responseString);

                    if (baseResponse != null)
                    {

                        action.User.Id = baseResponse.ItemId;

                        _dispatcher.Dispatch(new UpdateUserActionSuccess( action.User ));
                    }
                }
            }
            catch (Exception e)
            {
                _dispatcher.Dispatch(new UpdateUserActionFailure( $"something went wrong updating user with email : {action.User.Email}, error :{e}" ));
            }
        }
    }

};


using System.Security.Principal;
using Fluxor;

namespace FluxorRedux.State.User
{
    public class UserReducers
    {
        [ReducerMethod]
        public UserState StoreUserReducer(UserState state, StoreUserActionSuccess action)
        {
            return state with { Users = action.Users , IsFirstLoad = false ,IsLoading = false , Error = ""};
        }

        [ReducerMethod]
        public UserState StoreUserSetIsFirstLoadPropertyEffect(UserState state, SetIsLoadingPropertyAction action)
        {
            return state with { IsFirstLoad = action.IsFirstLoad };
        }
        
        [ReducerMethod]
        public UserState StoreUserSetIsLoadingPropertyEffect(UserState state, IsLoadingAction action)
        {
            return state with { IsLoading = action.IsLoading};
        }

        [ReducerMethod]
        public UserState DeleteUserReducer(UserState state, DeleteUserActionSuccess action)
        {
            var newUsers = state.Users.Where(user => user.Id != action.Id);

            return state with { Users = newUsers.ToList(), IsFirstLoad = false , Error = "" };
        }
    
        [ReducerMethod]
        public UserState DeleteUserFailureReducer(UserState state, DeleteUserActionFailure action)
        {
            return state with { Error = action.Error, IsFirstLoad = false };
        }

        [ReducerMethod]
        public UserState CreateUserReducer(UserState state, CreateUserActionSuccess action)
        {

            var newUsers = state.Users.ToList();

            newUsers.Insert(0, action.User);

            return state with{Users = newUsers};
        }

        [ReducerMethod]
        public UserState CreateUserFailureReducer(UserState state, CreateUserActionFailure action)
        {
            return state with { Error = action.Error };
        }
        
        [ReducerMethod]
        public UserState UpdateUserReducer(UserState state, UpdateUserActionSuccess action)
        {

            var index = state.Users.FindIndex(u => u.Id == action.User.Id);

            if ( index >= 0 )
            {
                state.Users[index] = action.User;
            }

            return state;
        }

        [ReducerMethod]
        public UserState UpdateUserFailureReducer(UserState state, UpdateUserActionFailure action)
        {
            return state with { Error = action.Error };
        }
    }
};


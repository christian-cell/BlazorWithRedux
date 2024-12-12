namespace FluxorRedux.State.User
{
    public class UserActions {}
    
    #region StoreUserActions

    public class StoreUserAction{}

    public class IsLoadingAction
    {
        public bool IsLoading;

        public IsLoadingAction(bool isLoading)
        {
            IsLoading = isLoading;
        }
    }

    public class StoreUserActionSuccess
    {
        public StoreUserActionSuccess(List<Models.User> users)
        {
            Users = users;
        }

        public List<Models.User> Users { get; set; }
    }

    public class StoreUserActionFailure
    {
        public StoreUserActionFailure(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public string ErrorMessage { get; set; }
    }

    public class SetIsLoadingPropertyAction
    {
        public bool IsFirstLoad;

        public SetIsLoadingPropertyAction(bool isFirstLoad)
        {
            IsFirstLoad = isFirstLoad;
        }
    }
    
    #endregion

    #region DeleteUsersActions

    public class DeleteUserAction
    {
        public Guid Id;

        public DeleteUserAction(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteUserActionSuccess
    {
        public Guid Id;

        public DeleteUserActionSuccess(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteUserActionFailure
    {
        public string Error;

        public DeleteUserActionFailure(string error)
        {
            Error = error;
        }
    }

    #endregion

    #region CreateUsersActions

    public class CreateUserAction
    {
        public Models.User User;

        public CreateUserAction(Models.User user)
        {
            User = user;
        }
    }
    
    public class CreateUserActionSuccess
    {
        public Models.User User;

        public CreateUserActionSuccess(Models.User user)
        {
            User = user;
        }
    }

    public class CreateUserActionFailure
    {
        public string Error;

        public CreateUserActionFailure(string error)
        {
            Error = error;
        }
    }

    #endregion

    #region UpdateUserActions

    public class UpdateUserAction
    {
        public Models.User User;

        public UpdateUserAction(Models.User user)
        {
            User = user;
        }
    }
    
    public class UpdateUserActionSuccess
    {
        public Models.User User;

        public UpdateUserActionSuccess(Models.User user)
        {
            User = user;
        }
    }

    public class UpdateUserActionFailure
    {
        public string Error;

        public UpdateUserActionFailure(string error)
        {
            Error = error;
        }
    }

    #endregion
};


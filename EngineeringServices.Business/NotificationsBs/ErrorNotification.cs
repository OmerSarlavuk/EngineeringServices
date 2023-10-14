namespace EngineeringServices.Business.NotificationsBs
{
    public static class ErrorNotification
    {
        //Admin Notifications
        public static string UserNameError = "Username Cannot Be Left Blank.";
        public static string UserNameLengthError = "Username must be at least 3 characters.";
        public static string ThisBlankError = "This cannot be left blank.";

        //NotFound
        public static string NotContentError = "Content not found.";

        //ID <= 0
        public static string IdError = "The id value cannot be less than or equal to 0. Please try entering a value greater than 0.";

        //enter ıd, no data
        public static string NotIdData = "data error corresponding to the entered ID number.";

        //GetAll
        public static string NotDataAll = "multiple future engineering data failed to arrive.";

        //Validation
        public static string MaxLimit = "It is limited to a maximum of 200 characters.";
        public static string MinLimit = "It is limited to a minimum of  20 characters.";
        public static string IsEmail = "Please enter a valid email address.";
    }
}

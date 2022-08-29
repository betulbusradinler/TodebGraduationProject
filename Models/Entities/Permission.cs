


namespace Models.Entities
{
    public enum Permission
    {
        CreditCardGetAll=1,
        CreditCardGetById,
        CreditCardPost,
        CreditCardGetPut,
        CreditCardDelete,

        ChatGetAll,
        ChatPost,
        ChatGetPut,
        ChatDelete,

        OneTimeBillingForAllFlatsControllerPost,

        FlatGetAll,
        FlatPost,
        FlatGetPut,
        FlatDelete,
        FlatGetPatch,

        UserGetAll,
        UserPost,
        UserGetPut,
        UserDelete,

        UtilityBillGetAll,
        UtilityBillPost,
        UtilityBillPut,
        UtilityBillDelete,

        UtilityBillTypeControllerGetAll,
        UtilityBillTypeControllerPost,
        UtilityBillTypeControllerPut,
        UtilityBillTypeControllerDelete,

        UserPasswordPatch


    }
}

namespace Blog.Infrastructure.Constants
{
    public static class DataBaseConstants
    {
        public const string DBPrefix = "fm_";

        //Databasenames
        public const string BlogPostTableName = DBPrefix + "blogPosts";
        public const string BlogPostKeywordTableName = DBPrefix + "blogPostKeywords";
        public const string BlogPostTagTableName = DBPrefix + "blogPostTags";
        public const string CommentTableName = DBPrefix + "comments";
        public const string KeywordTableName = DBPrefix + "keywords";
        public const string SettingsTableName = DBPrefix + "settings";
        public const string TagTableName = DBPrefix + "tags";

        public const string MailListTableName = DBPrefix + "mailLists";
        public const string MailListSubscribeTableName = DBPrefix + "mailListsSubscribers";
        public const string SubscriberTableName = DBPrefix + "subscribers";
        public const string LibraryTableName = DBPrefix + "libraries";
        public const string FilesTableName = DBPrefix + "files";
        public const string LinkTableName = DBPrefix + "links";

        public const string OpenGraphTableName = DBPrefix + "openGraphs";

        public const string UserTableName = DBPrefix + "users";
        public const string RolesTableName = DBPrefix + "roles";
        public const string UserRolesTableName = DBPrefix + "userRoles";
        public const string UserClaimsTableName = DBPrefix + "userClaims";
        public const string UserLoginTableName = DBPrefix + "userLogins";
        public const string UserTokenTableName = DBPrefix + "userTokens";
        public const string RoleClaimTableName = DBPrefix + "roleClaims";

    }
}

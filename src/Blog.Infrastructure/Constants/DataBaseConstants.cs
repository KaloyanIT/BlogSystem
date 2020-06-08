namespace Blog.Infrastructure.Constants
{
    public static class DataBaseConstants
    {
        public const string DB_PREFIX = "fm_";

        //Databasenames
        public const string BLOG_POST_TABLE_NAME = DB_PREFIX + "blogPosts";
        public const string BLOG_POST_KEYWORD_TABLE_NAME = DB_PREFIX + "blogPostKeywords";
        public const string BLOG_POST_TAG_TABLE_NAME = DB_PREFIX + "blogPostTags";
        public const string COMMENT_TABLE_NAME = DB_PREFIX + "comments";
        public const string KEYWORD_TABLE_NAME = DB_PREFIX + "keywords";
        public const string SETTINGS_TABLE_NAME = DB_PREFIX + "settings";
        public const string TAG_TABLE_NAME = DB_PREFIX + "tags";

        public const string MAIL_LIST_TABLE_NAME = DB_PREFIX + "mailLists";
        public const string MAIL_LIST_SUBSCRIBER_TABLE_NAME = DB_PREFIX + "mailListsSubscribers";
        public const string SUBSCRIBER_TABLE_NAME = DB_PREFIX + "subscribers";


    }
}

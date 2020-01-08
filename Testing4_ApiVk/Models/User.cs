namespace Testing4_ApiVk.Models
{
    public class User
    {
        public string id { get; set; } //идентификатор пользователя.
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool is_closed { get; set; } //скрыт ли профиль пользователя настройками приватности.
        public string birthday { get; set; }
    }
}
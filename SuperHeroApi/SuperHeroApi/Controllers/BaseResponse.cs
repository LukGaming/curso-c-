namespace SuperHeroApi.Controllers
{
    public class BaseResponse
    {
        public string message { get; set; } = string.Empty;
        public bool sucesso { get; set; }
        public object response { get; set; }
    }
}
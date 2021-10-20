namespace FoodDelivery.Model
{
    public class Response
    {
        public bool Succes { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }


        public Response(bool Succes, string Token, string Message)
        {
            this.Succes = Succes;
            this.Token = Token;
            this.Message = Message;
        }


        public Response(bool Succes, string Message)
        {
            this.Succes = Succes;
            this.Message = Message;
        }

        public Response() { }
    }
}
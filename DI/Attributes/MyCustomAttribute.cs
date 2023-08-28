namespace DI.Attributes
{
    // a custom attribute; pay attention to the naming convention
    public class MyCustomAttribute: Attribute
    {
        // the data that this attribute bears
        public readonly string secret;
        public MyCustomAttribute() {
            this.secret = "Highly classified";
        }
    }
}

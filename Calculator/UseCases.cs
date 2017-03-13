namespace Calculator
{
    public class UseCases
    {
        private readonly RequestHandler requestHandler;

        public UseCases()
        {
            requestHandler = new RequestHandler();
        }

        public double OperandErweitern(char ziffer)
        {
            requestHandler.ZifferAnhängen(ziffer);
            return requestHandler.Operand;
        }
    }
}
namespace Helpers
{
    public static class ValidateStrings
    {
        /// <summary>
        /// Valida se a string informada possui o tamanho mínimo
        /// </summary>
        /// <param name="value">string a ser analizada</param>
        /// <param name="size">tamanho desejado</param>
        /// <returns>Verdadeiro se a string possuir o tamanho informado</returns>
        public static bool validateStringMinSize(string value, int minSize)
        {
            var isValid = true;

            if(string.IsNullOrEmpty(value) || value.Length < minSize)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}

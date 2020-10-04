Métodos de extensão para a classe string. Provê um conjunto de validações e formatações para os mais variados tipos de dados como CNPJ, CPF, telefone e etc.

## REQUISITOS
* Dotnet Core 3.1 or higher 
* Visual Studio 2019

## MÉTODO DE EXTENSÃO
Método        | Descrição
---------     | ------
IsCNPJValid() | Valida se a string é um CNPJ válido. Retorna um valor booleano(true ou false)
FormatCNPJ() | Retorna uma string formato no estilo de CNPJ. Ex: xx.xxx.xxx/xxxx-xx

## COMO USAR
Para usar os métodos de extensão basta adicionar a referência do assembly 
ao seu projeto. Após adição os métodos de validação estão disponíveis para qualquer objeto do tipo string.

~~~IsCNPJValid()
using Validations.Data;

namespace Exemple
{
    public class MyExemple
    {
        public bool ValidateCNPJ(string cnpj)
        {
            var isValid = cnpj.IsCNPJValid(); // returns true or false
            return isValid;
        }
    }
}
~~~

~~~FormatCNPJ()
using Validations.Data;

namespace Exemple
{
    public class MyExemple
    {
        public string FormatCNPJ(string cnpj /* cnpj = xxxxxxxxxxxxxx */)
        {
            var formattedCnpj = cnpj.FormatCNPJ(); // returns xx.xxx.xxx/xxxx-xx
            return formattedCnpj;
        }
    }
}
~~~
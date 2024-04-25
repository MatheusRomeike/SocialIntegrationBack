public class PtBr : ITranslation
{
    public string Error => "Erro";

    public string GetErrorMessage(Type type)
    {
        if (type == typeof(ArgumentNullException))
            return "Argumento nulo";
        if (type == typeof(ArgumentException))
            return "Argumento inválido";
        if (type == typeof(InvalidOperationException))
            return "Operação inválida";
        if (type == typeof(NotImplementedException))
            return "Método não implementado";
        if (type == typeof(NotSupportedException))
            return "Operação não suportada";
        if (type == typeof(NullReferenceException))
            return "Referência nula";
        if (type == typeof(FormatException))
            return "Formato inválido";
        if (type == typeof(OverflowException))
            return "Estouro";
        if (type == typeof(InvalidCastException))
            return "Conversão inválida";
        if (type == typeof(IndexOutOfRangeException))
            return "Índice fora do intervalo";
        if (type == typeof(TimeoutException))
            return "Tempo limite excedido";
        if (type == typeof(InvalidOperationException))
            return "Operação inválida";
        if (type == typeof(NotImplementedException))
            return "Método não implementado";
        if (type == typeof(NotSupportedException))
            return "Operação não suportada";
        if (type == typeof(NullReferenceException))
            return "Referência nula";
        if (type == typeof(FormatException))
            return "Formato inválido";
        if (type == typeof(OverflowException))
            return "Estouro";
        if (type == typeof(InvalidCastException))
            return "Conversão inválida";
        if (type == typeof(IndexOutOfRangeException))
            return "Índice fora do intervalo";
        if (type == typeof(TimeoutException))
            return "Tempo limite excedido";
        return "Erro";
    }
}

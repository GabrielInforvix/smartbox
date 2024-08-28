using System.ComponentModel;

namespace smartbox.Enums
{
    public enum StatePackage
    {
        [Description("Aguardando Retirada!")]
        Aguardando = 1,
        [Description("Pacote retirado!")]
        Retirado = 2
    }
}

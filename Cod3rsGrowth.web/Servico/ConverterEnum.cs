using Cod3rsGrowth.dominio;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cod3rsGrowth.web.Servico
{
    public class ConverterEnum<T> : JsonConverter<T> where T : Enum
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            int value = reader.GetInt32();
            return (T?)Enum.ToObject(typeof(T), value);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(PegarDescricaoEnum(value));
        }
        public static string PegarDescricaoEnum(Enum value)
        {
            const int valorMinimo = 0;
            const int valorInicial = 0;

            var campo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] atributos = (DescriptionAttribute[])campo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return atributos.Length > valorMinimo ? atributos[valorInicial].Description : value.ToString();
        }
    }
}

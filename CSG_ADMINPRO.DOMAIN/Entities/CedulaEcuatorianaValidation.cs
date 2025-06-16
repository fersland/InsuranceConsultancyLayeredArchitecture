using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DOMAIN.Entities
{
    public class CedulaEcuatorianaValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string cedula = value as string;

            if (string.IsNullOrWhiteSpace(cedula) || cedula.Length != 10)
                return false;

            int provincia = int.Parse(cedula.Substring(0, 2));
            if (provincia < 1 || provincia > 24)
                return false;

            int[] coef = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int suma = 0;
            for (int i = 0; i < 9; i++)
            {
                int valor = int.Parse(cedula[i].ToString()) * coef[i];
                if (valor > 9) valor -= 9;
                suma += valor;
            }

            int digitoVerificador = int.Parse(cedula[9].ToString());
            int resultado = 10 - (suma % 10);
            if (resultado == 10) resultado = 0;

            return resultado == digitoVerificador;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AlquilerDeVehiculos.Modelos
{
    public class AlquileresModel
    {
        public int id_alquiler {  get; set; }
        public int id_cliente { get; set; }
        public int id_vehiculo { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public decimal costo { get; set; }

        public string nombre_cliente { get; set; }
        public string placa_vehiculo { get; set; }
    }
}

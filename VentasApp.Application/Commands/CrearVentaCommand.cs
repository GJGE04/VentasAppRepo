using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Core.Entities;

namespace VentasApp.Application.Commands
{
    public class CrearVentaCommand : IRequest<int>
    {
        public List<VentaDetalle> VentaDetalles { get; set; }
        public decimal Total { get; set; }
    }
}

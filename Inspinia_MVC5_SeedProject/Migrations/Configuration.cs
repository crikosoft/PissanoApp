namespace PissanoApp.Migrations
{
    using PissanoApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PissanoApp.Models.PissanoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PissanoApp.Models.PissanoContext context)
        {

            var tipoMaterial = new List<TipoMaterial>
            {
                new TipoMaterial { nombre= "Materiales"},
                new TipoMaterial { nombre= "SubContratos"}

            };

            tipoMaterial.ForEach(s => context.TipoMateriales.AddOrUpdate(p => p.nombre, s));
            context.SaveChanges();

            var tipoCompras = new List<TipoCompra>
            {
                new TipoCompra { nombre= "Materiales"},
                new TipoCompra { nombre= "SubContratos"}

            };

            tipoCompras.ForEach(s => context.TipoCompra.AddOrUpdate(p => p.nombre, s));
            context.SaveChanges();

            var monedas = new List<Moneda>
            {
                new Moneda { nombre= "Soles"},
                new Moneda { nombre= "Dolares"}

            };

            monedas.ForEach(s => context.Monedas.AddOrUpdate(p => p.nombre, s));
            context.SaveChanges();

            var unidadMedida = new List<UnidadMedida>
            {
                new UnidadMedida { nombre= "bls", sigla="bls"},
                new UnidadMedida { nombre= "bol", sigla="bol"},
                new UnidadMedida { nombre= "cja", sigla="cja"},
                new UnidadMedida { nombre= "dia", sigla="dia"},
                new UnidadMedida { nombre= "gal", sigla="gal"},
                new UnidadMedida { nombre= "glb", sigla="glb"},
                new UnidadMedida { nombre= "gln", sigla="gln"},
                new UnidadMedida { nombre= "hh", sigla="hh"},
                new UnidadMedida { nombre= "hm", sigla="hm"},
                new UnidadMedida { nombre= "kg", sigla="kg"},
                new UnidadMedida { nombre= "m", sigla="m"},
                new UnidadMedida { nombre= "m2", sigla="m2"},
                new UnidadMedida { nombre= "m3", sigla="m3"},
                new UnidadMedida { nombre= "mes", sigla="mes"},
                new UnidadMedida { nombre= "ml", sigla="ml"},
                new UnidadMedida { nombre= "p2", sigla="p2"},
                new UnidadMedida { nombre= "und", sigla="und"},
                new UnidadMedida { nombre= "Vje", sigla="Vje"},
                new UnidadMedida { nombre= "Par", sigla="Par"},
                new UnidadMedida { nombre= "Jgo", sigla="Jgo"},
                new UnidadMedida { nombre= "Rollo", sigla="Rollo"},
                new UnidadMedida { nombre= "Mill", sigla="Mill"},
                new UnidadMedida { nombre= "Var", sigla="Var"},
                new UnidadMedida { nombre= "%MO", sigla="%MO"}
            };

            unidadMedida.ForEach(s => context.UnidadMedidas.AddOrUpdate(p => p.nombre, s));
            context.SaveChanges();



            var prioridades = new List<Prioridad>
            {
                new Prioridad { nombre= "Urgencia", plazoDias = 2},
                new Prioridad { nombre= "Emergencia", plazoDias = 1},
                new Prioridad { nombre= "Regular", plazoDias = 4}

            };

            prioridades.ForEach(s => context.Prioridad.AddOrUpdate(p => p.nombre, s));
            context.SaveChanges();


            var empresas = new List<Empresa>
            {
                new Empresa { nombre= "PISSANO SAC", ruc= "20251059749", agenteRetenedor = true, telefono="346-2454 / 346-1989", direccion="Av. San Luis 1369 - San luis"},
                new Empresa { nombre= "Consorcio PISSANO S.A.C.", ruc="20600375602", agenteRetenedor=false, telefono = "346-2454 / 346-1989", direccion="Av. San Luis 1363 - San Luis"}

            };

            empresas.ForEach(s => context.Empresas.AddOrUpdate(p => p.nombre, s));
            context.SaveChanges();


            var obras = new List<Obra>
            {
                new Obra { nombre= "Sucre", direccion= "EDIFICIO MULTIFAMILIAR SUCRE - MIRAFLORES", fechaInicio= DateTime.Today, fechaFin= DateTime.Today.AddMonths(12), tiempoEjecucion=12, 
                    empresaId = empresas.Single(s => s.nombre == "PISSANO SAC" ).empresaId},
                new Obra { nombre= "San Borja Norte", direccion= "RESIDENCIAL  SAN BORJA NORTE" , fechaInicio= DateTime.Today, fechaFin= DateTime.Today.AddMonths(12), tiempoEjecucion=12,
                    empresaId = empresas.Single(s => s.nombre == "PISSANO SAC" ).empresaId},
                new Obra { nombre= "Barcelona", direccion= "BARCELONA" , fechaInicio= DateTime.Today, fechaFin= DateTime.Today.AddMonths(12), tiempoEjecucion=12,
                    empresaId = empresas.Single(s => s.nombre == "PISSANO SAC" ).empresaId},

            };

            obras.ForEach(s => context.Obras.AddOrUpdate(p => p.direccion, s));
            context.SaveChanges();


            var tiposPresupuesto = new List<TipoPresupuesto>
            {
                new TipoPresupuesto { descripcion = "Presupuesto Itemizado"},
                new TipoPresupuesto { descripcion = "Presupuesto con Partidas de Control"}

            };


            tiposPresupuesto.ForEach(s => context.TipoPresupuestoes.AddOrUpdate(p => p.descripcion, s));
            context.SaveChanges();


            var estadosOrden = new List<EstadoOrden>
            {
                new EstadoOrden { descripcion = "Pendiente de Aprobación", nombre = "Pendiente de Aprobación"},
                new EstadoOrden { descripcion = "Aprobado y Enviado", nombre = "Aprobado y Enviado"},
                new EstadoOrden { descripcion = "Orden Recibida Parcial", nombre = "Orden Recibida Parcial"},
                new EstadoOrden { descripcion = "Orden Recibida Total", nombre = "Orden Recibida Total"}

            };

            estadosOrden.ForEach(s => context.EstadoOrdenes.AddOrUpdate(p => p.descripcion, s));
            context.SaveChanges();

            var estadosOrdenDetalle = new List<EstadoOrdenDetalle>
            {
                new EstadoOrdenDetalle { descripcion = "Pendiente Atención", nombre = "Pendiente Atención"},
                new EstadoOrdenDetalle { descripcion = "Atendido Parcial", nombre = "Atendido Parcial"},
                new EstadoOrdenDetalle { descripcion = "Atendido Total", nombre = "Atendido Total"}

            };

            estadosOrdenDetalle.ForEach(s => context.EstadoOrdenDetalles.AddOrUpdate(p => p.descripcion, s));
            context.SaveChanges();



            var formaPagos = new List<FormaPago>
            {
                new FormaPago { nombre = "Contado"},
                new FormaPago { nombre = "Crédito"},
                new FormaPago { nombre = "Crédito a 20 días"},
                new FormaPago { nombre = "Crédito 30 días"},
                new FormaPago { nombre = "Crédito a 45 días"},
                new FormaPago { nombre = "Factura a 7 días"},
                new FormaPago { nombre = "Factura a 15 días"},
                new FormaPago { nombre = "Factura a 20 días"},
                new FormaPago { nombre = "Factura a 30 días"},
                new FormaPago { nombre = "Factura a 45 días"},
                new FormaPago { nombre = "Letra a 30 días"},
                new FormaPago { nombre = "Letra a 35 días"},
                new FormaPago { nombre = "Letra a 45 días"},
                new FormaPago { nombre = "Cheque diferido a 15 días"},
                new FormaPago { nombre = "Cheque diferido a 30 días"},
                new FormaPago { nombre = "En proceso"}

            };


            formaPagos.ForEach(s => context.FormaPagos.AddOrUpdate(p => p.nombre, s));
            context.SaveChanges();




            var subPresupuesto = new List<SubPresupuesto>
            {
                new SubPresupuesto { nombre = "Estructuras"},
                new SubPresupuesto { nombre = "Arquitectura"},
                new SubPresupuesto { nombre = "IISS (Instalaciones Sanitarias)"},
                new SubPresupuesto { nombre = "IIEE (Instalaciones Eléctricas)"},
                new SubPresupuesto { nombre = "Instalaciones Mecánicas"},
                new SubPresupuesto { nombre = "Gastos Generales"},

            };

            subPresupuesto.ForEach(s => context.SubPresupuesto.AddOrUpdate(p => p.nombre,s));
            context.SaveChanges();

            var presupuestos = new List<Presupuesto>
            {
                new Presupuesto { descripcion = "Presupuesto Itemizado de Obra San Borja Norte", plazo=12, fecha = DateTime.Today, 
                    obraId = obras.Single(s => s.direccion =="RESIDENCIAL  SAN BORJA NORTE").id,
                    tipoPresupuestoId  =  tiposPresupuesto.Single(s => s.descripcion =="Presupuesto Itemizado").tipoPresupuestoId,
                    monedaId = monedas.Single(s => s.nombre == "Soles").monedaId}
             };

            presupuestos.ForEach(s => context.Presupuestos.AddOrUpdate(p => p.descripcion, s));
            context.SaveChanges();


            var materialpadres = new List<Material>
            {
                new  Material { codigo="20001001", nombre= "Acero corrugado f'y = 4200 Kg/cm2", MaterialPadre=null,
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "Var").unidadMedidaId
                },

                new  Material { codigo="20001002", nombre= "Concreto Premezclado", MaterialPadre=null,
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId
                },

                new  Material { codigo="20001003", nombre= "Cemento Portland ", MaterialPadre=null,
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "bls").unidadMedidaId
                },

                new  Material { codigo="20001004", nombre= "Alambre Negro Recocido", MaterialPadre=null,
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId
                },

                new  Material { codigo="20001005", nombre= "Agregados", MaterialPadre=null,
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId
                },


                // SubContratos

                new  Material { codigo="20000001", nombre= "Alquiler de baños portatiles", MaterialPadre=null,
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "SubContratos").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId
                },
                

                new  Material { codigo="20000002", nombre= "Alquiler de lavaderos portatiles", MaterialPadre=null,
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "SubContratos").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId
                },

                new  Material { codigo="20000003", nombre= "Alquiler de duchas portatiles", MaterialPadre=null,
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "SubContratos").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId
                },

                new  Material { codigo="20000004", nombre= "Alquiler de encofrado metálico", MaterialPadre=null,
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "SubContratos").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId
                }

            };

            materialpadres.ForEach(s => context.Materiales.AddOrUpdate(p => p.codigo, s));
            context.SaveChanges();


            var materialhijos = new List<Material>
            {

                new  Material { codigo="20001001-0001", nombre= "Acero corrugado f'y = 4200 Kg/cm2 G-60 Ø 1/4' x 9 Mt.",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "Var").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001001").materialId
                },


                new  Material { codigo="20001001-0002", nombre= "Acero corrugado f'y = 4200 Kg/cm2 G-60 Ø 8mm x 9 Mt.",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "Var").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001001").materialId
                },

                new  Material { codigo="20001001-0003", nombre= "Acero corrugado f'y = 4200 Kg/cm2 G-60 Ø 3/8' x 9 Mt.",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "Var").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001001").materialId
                },


                new  Material { codigo="20001001-0004", nombre= "Acero corrugado f'y = 4200 Kg/cm2  G-60 Ø 1/2' x 9 Mt.",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "Var").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001001").materialId
                },

                new  Material { codigo="20001001-0005", nombre= "Acero corrugado f'y = 4200 Kg/cm2 G-60 Ø 5/8' x 9 Mt.",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "Var").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001001").materialId
                },

                new  Material { codigo="20001001-0006", nombre= "Acero corrugado f'y = 4200 Kg/cm2 G-60 Ø 3/4' x 9 Mt.",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "Var").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001001").materialId
                },

                new  Material { codigo="20001001-0007", nombre= "Acero corrugado f'y = 4200 Kg/cm2 G-60 Ø 1' x 9 Mt.",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "Var").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001001").materialId
                },

                new  Material { codigo="20001001-0008", nombre= "Acero corrugado f'y = 4200 Kg/cm2 G-60 Ø 1 3/8' x 9 Mt.",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "Var").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001001").materialId
                },

                // 02

                new  Material { codigo="20001002-0001", nombre= "Concreto Premezclado 210 kg/cm2 Slump 4' - 6' Huso 57",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },


                new  Material { codigo="20001002-0002", nombre= "Concreto Premezclado 210 kg/cm2 Slump 4' - 6' Huso 67",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },

                new  Material { codigo="20001002-0003", nombre= "Concreto Premezclado 210 kg/cm2 c/ imp Slump 4' - 6' Huso 67",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },


                new  Material { codigo="20001002-0004", nombre= "Concreto Premezclado 245 kg/cm2 Slump 4' - 6' Huso 57",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },

                new  Material { codigo="20001002-0005", nombre= "Concreto Premezclado 245 kg/cm2 Slump 4' - 6' Huso 67",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },

                new  Material { codigo="20001002-0006", nombre= "Concreto Premezclado 245 kg/cm2 c/ imp Slump 4' - 6' Huso 67",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },

                new  Material { codigo="20001002-0007", nombre= "Concreto Premezclado 280 kg/cm2 Slump 4' - 6' Huso 57",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },

                new  Material { codigo="20001002-0008", nombre= "Concreto Premezclado 280 kg/cm2 Slump 4' - 6' Huso 67",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },


                new  Material { codigo="20001002-0009", nombre= "Concreto Premezclado 280 kg/cm2 c/ imp Slump 4' - 6' Huso 67",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },


                new  Material { codigo="20001002-0010", nombre= "Concreto Premezclado 350 kg/cm2 Slump 4' - 6' Huso 57",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },

                new  Material { codigo="20001002-0011", nombre= "Concreto Premezclado 350 kg/cm2 Slump 4' - 6' Huso 67",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },

                new  Material { codigo="20001002-0012", nombre= "Concreto Premezclado 350 kg/cm2 c/ imp Slump 4' - 6' Huso 67",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },

                new  Material { codigo="20001002-0013", nombre= "Mortero Premezclado 1:6",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },

                new  Material { codigo="20001002-0014", nombre= "Mortero Premezclado 1:6",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001002").materialId
                },                


                // 3


                new  Material { codigo="20001003-0001", nombre= "Cemento Sol Portland Tipo I (42.5 kg)",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "bls").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001003").materialId
                },


                new  Material { codigo="20001003-0002", nombre= "Cemento APU Portland GU (42.5 kg)",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "bls").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001003").materialId
                },

                new  Material { codigo="20001003-0003", nombre= "Cemento Andino Portland Tipo V (42.5 kg)",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "bls").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001003").materialId
                },

                // 4

                new  Material { codigo="20001004-0001", nombre= "Alambre Negro Recocido # 16",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "bls").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001004").materialId
                },


                new  Material { codigo="20001004-0002", nombre= "Alambre Negro Recocido # 8",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "bls").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001004").materialId
                },


                // 5

                new  Material { codigo="20001005-0001", nombre= "Confitillo",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001004").materialId
                },


                new  Material { codigo="20001005-0002", nombre= "Arena Fina",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001004").materialId
                },


                new  Material { codigo="20001005-0003", nombre= "Arena Gruesa",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001005").materialId
                },

                new  Material { codigo="20001005-0004", nombre= "Piedra Chancada de 1/2'",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001005").materialId
                },

                new  Material { codigo="20001005-0005", nombre= "Piedra Chancada de 3/4' a 1'",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001005").materialId
                },

                new  Material { codigo="20001005-0006", nombre= "Piedra de Zanja 6'",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001005").materialId
                },

                new  Material { codigo="20001005-0007", nombre= "Piedra de Zanja 8'",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001005").materialId
                },


                new  Material { codigo="20001005-0008", nombre= "Hormigón",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001005").materialId
                },


                new  Material { codigo="20001005-0009", nombre= "Arena Fina",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "bls").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001005").materialId
                },

                new  Material { codigo="20001005-0010", nombre= "Arena Gruesa",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "bls").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001005").materialId
                },

                new  Material { codigo="20001005-0011", nombre= "Piedra Chancada de 1/2'",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "Materiales").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "bls").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20001005").materialId
                },


                // SubContratos 01


                new  Material { codigo="20000001-001", nombre= "Alquiler de Baños Portatiles Estándar",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "SubContratos").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20000001").materialId
                },

                new  Material { codigo="20000001-002", nombre= "Alquiler de Baños Portatiles C/Lavamanos",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "SubContratos").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20000001").materialId
                },



                // SubContratos 02


                new  Material { codigo="20000002-001", nombre= "Alquiler de lavaderos portatiles P/Obreros",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "SubContratos").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20000002").materialId
                },

                new  Material { codigo="20000002-002", nombre= "Alquiler de lavaderos portatiles Ejecutivo",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "SubContratos").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20000002").materialId
                },


                // SubContratos 03


                new  Material { codigo="20000003-001", nombre= "Alquiler de duchas portatiles",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "SubContratos").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20000003").materialId
                },

                // SubContratos 04


                new  Material { codigo="20000004-001", nombre= "Alquiler de encofrado metalico de Placas",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "SubContratos").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20000004").materialId
                },

                new  Material { codigo="20000004-002", nombre= "Alquiler de encofrado metalico de Columnas",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "SubContratos").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20000004").materialId
                },

                new  Material { codigo="20000004-003", nombre= "Alquiler de encofrado metalico de techo",
                tipoMaterialId = tipoMaterial.Single(s => s.nombre == "SubContratos").tipoMaterialId,
                unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId,
                materialPadreId = materialpadres.Single(s => s.codigo == "20000004").materialId
                }

            };


            materialhijos.ForEach(s => context.Materiales.AddOrUpdate(p => p.codigo, s));
            context.SaveChanges();


            var titulo = new List<Titulo>
            {
                new Titulo {  nombre ="OBRAS PRELIMINARES", descripcion = "OBRAS PRELIMINARES" },
                new Titulo {  nombre ="DEMOLICIONES", descripcion = "DEMOLICIONES" },
                new Titulo {  nombre ="MOVIMIENTO DE TIERRAS (INCL. RELLENOS Y AFIRMADOS)", descripcion = "MOVIMIENTO DE TIERRAS (INCL. RELLENOS Y AFIRMADOS)" },
                new Titulo {  nombre ="OBRAS DE CONCRETO SIMPLE", descripcion = "OBRAS DE CONCRETO SIMPLE" },
                new Titulo {  nombre ="ESTABILIZACION DE TALUDES (MURO PANTALLA)", descripcion = "ESTABILIZACION DE TALUDES (MURO PANTALLA)" },
                new Titulo {  nombre ="ENCOFRADO Y DESENCOFRADO", descripcion = "ENCOFRADO Y DESENCOFRADO" },
                new Titulo {  nombre ="ACERO CORRUGADO f'y=4200 Kg/cm2", descripcion = "ACERO CORRUGADO f'y=4200 Kg/cm2" },
                new Titulo {  nombre ="CONCRETO", descripcion = "CONCRETO" },
                new Titulo {  nombre ="LOSAS ALIGERADA DE H=25 CMS ( INCLUYE LAS RAMPAS )", descripcion = "LOSAS ALIGERADA DE H=25 CMS ( INCLUYE LAS RAMPAS )" },
                new Titulo {  nombre ="JUNTAS y DINTELES", descripcion = "JUNTAS y DINTELES" },
                //2. ITEM ARQUI
                new Titulo {  nombre ="ALBAÑILERIA", descripcion = "ALBAÑILERIA" },
                new Titulo {  nombre ="REVOQUES ENLUCIDOS Y MOLDURAS", descripcion = "REVOQUES ENLUCIDOS Y MOLDURAS" },
                new Titulo {  nombre ="SOLAQUEOS", descripcion = "SOLAQUEOS" },
                new Titulo {  nombre ="PISOS Y PAVIMENTOS", descripcion = "PISOS Y PAVIMENTOS" },
                new Titulo {  nombre ="ZOCALOS Y CONTRAZOCALOS", descripcion = "ZOCALOS Y CONTRAZOCALOS" },
                new Titulo {  nombre ="CARPINTERIA DE MADERA", descripcion = "CARPINTERIA DE MADERA" },
                new Titulo {  nombre ="MUEBLES ", descripcion = "MUEBLES " },
                new Titulo {  nombre ="CLOSETS", descripcion = "CLOSETS" },
                new Titulo {  nombre ="TABLEROS", descripcion = "TABLEROS" },
                new Titulo {  nombre ="CARPINTERIA METALICA", descripcion = "CARPINTERIA METALICA" },
                new Titulo {  nombre ="CERRAJERIA", descripcion = "CERRAJERIA" },
                new Titulo {  nombre ="VIDRIOS CRISTALES Y SIMILARES", descripcion = "VIDRIOS CRISTALES Y SIMILARES" },
                new Titulo {  nombre ="PINTURA", descripcion = "PINTURA" },
                new Titulo {  nombre ="APARATOS SANITARIOS", descripcion = "APARATOS SANITARIOS" },
                new Titulo {  nombre ="ACCESORIOS PARA BAÑOS", descripcion = "ACCESORIOS PARA BAÑOS" },
                new Titulo {  nombre ="SEÑALES", descripcion = "SEÑALES" },
                new Titulo {  nombre ="LUMINARIAS", descripcion = "LUMINARIAS" },
                new Titulo {  nombre ="CUBIERTAS", descripcion = "CUBIERTAS" },
                new Titulo {  nombre ="OBRAS EXTERIORES", descripcion = "OBRAS EXTERIORES" },
                new Titulo {  nombre ="VARIOS", descripcion = "VARIOS" },
                //3. ITEM IISS
                new Titulo {  nombre ="SISTEMA DE AGUA FRIA", descripcion = "SISTEMA DE AGUA FRIA" },
                new Titulo {  nombre ="SISTEMA DE AGUA CALIENTE", descripcion = "SISTEMA DE AGUA CALIENTE" },
                new Titulo {  nombre ="SISTEMA DE DESAGÜE", descripcion = "SISTEMA DE DESAGÜE" },
                new Titulo {  nombre ="SISTEMA AGUA CONTRA INCENDIO (ACI)", descripcion = "SISTEMA AGUA CONTRA INCENDIO (ACI)" },
                new Titulo {  nombre ="CUARTO DE BOMBAS", descripcion = "CUARTO DE BOMBAS" },
                new Titulo {  nombre ="EQUIPAMIENTO (incluye accesorios, instalación y todo lo requerido para su correcto funcionamiento)", descripcion = "EQUIPAMIENTO (incluye accesorios, instalación y todo lo requerido para su correcto funcionamiento)" },

                
                //4. ITEM IIEE
                new Titulo {  nombre ="SALIDAS", descripcion = "SALIDAS" },
                new Titulo {  nombre ="ALIMENTADORES ELECTRICOS  (CON CABLE LIBRE HALOGENOS NH 80)", descripcion = "ALIMENTADORES ELECTRICOS  (CON CABLE LIBRE HALOGENOS NH 80)" },
                new Titulo {  nombre ="TUBERÍAS, BANDEJAS, INST. LUMINARIAS ", descripcion = "TUBERÍAS, BANDEJAS, INST. LUMINARIAS " },
                new Titulo {  nombre ="CAJAS DE PASE", descripcion = "CAJAS DE PASE" },
                new Titulo {  nombre ="ARTEFACTOS DE TOMACORRIENTE E INTERRUPTORES", descripcion = "ARTEFACTOS DE TOMACORRIENTE E INTERRUPTORES" },
                //new Titulo {  nombre ="TABLEROS", descripcion = "TABLEROS" },
                new Titulo {  nombre ="SALIDAS PARA COMUNICACIONES ", descripcion = "SALIDAS PARA COMUNICACIONES " },
                new Titulo {  nombre ="TUBOS PARA MONTANTES DE COMUNICACIONES (TELEFONO TV. INTER.,SCI)", descripcion = "TUBOS PARA MONTANTES DE COMUNICACIONES (TELEFONO TV. INTER.,SCI)" },
                new Titulo {  nombre ="POZO DE TIERRA", descripcion = "POZO DE TIERRA" },
                new Titulo {  nombre ="SISTEMAS, GE Y VARIOS", descripcion = "SISTEMAS, GE Y VARIOS" },
                
                //5.ITEM INST MECAN
                new Titulo {  nombre ="SISTEMA DE GAS", descripcion = "SISTEMA DE GAS" },
                new Titulo {  nombre ="SISTEMA DE EXTRACCIÓN DE CO", descripcion = "SISTEMA DE EXTRACCIÓN DE CO" },
                new Titulo {  nombre ="SISTEMA DE VENTILACIÓN", descripcion = "SISTEMA DE VENTILACIÓN" },
                new Titulo {  nombre ="EQUIPOS ", descripcion = "EQUIPOS " },

                //6. ITEM. GAST.GRLS
                new Titulo {  nombre ="OFICINA CENTRAL/OBRA", descripcion = "OFICINA CENTRAL/OBRA" },
                new Titulo {  nombre ="OBRA", descripcion = "OBRA" },
                new Titulo {  nombre ="EQUIPO DE OFICINA DE LA OBRA", descripcion = "EQUIPO DE OFICINA DE LA OBRA" },
                //new Titulo {  nombre ="VARIOS", descripcion = "VARIOS" },
                new Titulo {  nombre ="GASTOS FINANCIEROS", descripcion = "GASTOS FINANCIEROS" }
                                 
            };


            titulo.ForEach(s => context.Titulo.AddOrUpdate(p => p.nombre, s));
            context.SaveChanges();


            var partidas = new List<Partida>
            {
                new Partida {  nombre ="TRAZO Y REPLANTEO DE OBRA", descripcion = "TRAZO Y REPLANTEO DE OBRA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="GUARDIANIA Y CUSTODIA PERMANENTE EN OBRA (MARRONES)", descripcion = "GUARDIANIA Y CUSTODIA PERMANENTE EN OBRA (MARRONES)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="LIMPIEZA PERMANENTE DE OBRA (INCL. SALA DE VENTAS Y PILOTO)", descripcion = "LIMPIEZA PERMANENTE DE OBRA (INCL. SALA DE VENTAS Y PILOTO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="NIVELACION Y APISONADO PARA FALSO PISO", descripcion = "NIVELACION Y APISONADO PARA FALSO PISO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CONTROL TOPOGRAFICO DURANTE LA OBRA", descripcion = "CONTROL TOPOGRAFICO DURANTE LA OBRA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="IMPLEMENTACIÓN DE PLAN DE SEGURIDAD, SALUD Y MEDIO AMBIENTE EN OBRA (Pasarelas, barandas, escaleras metálica, señalización, andamios, protección permanente zonas de altura contra caídas objetos etc)", descripcion = "IMPLEMENTACIÓN DE PLAN DE SEGURIDAD, SALUD Y MEDIO AMBIENTE EN OBRA (Pasarelas, barandas, escaleras metálica, señalización, andamios, protección permanente zonas de altura contra caídas objetos etc)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="MANEJO AMBIENTAL", descripcion = "MANEJO AMBIENTAL", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="ELEMENTOS DE SEGURIDAD", descripcion = "ELEMENTOS DE SEGURIDAD", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="CAPACITACIÓN EN SEGURIDAD Y SALUD", descripcion = "CAPACITACIÓN EN SEGURIDAD Y SALUD", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="SEÑALIZACION EN ZONAS DE SEGURIDAD", descripcion = "SEÑALIZACION EN ZONAS DE SEGURIDAD", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="EQUIPOS DE PROTECCIÓN INDIVIDUAL", descripcion = "EQUIPOS DE PROTECCIÓN INDIVIDUAL", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="CERCO PERIMETRAL DE OBRA", descripcion = "CERCO PERIMETRAL DE OBRA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="OFICINAS, ALMACENES, VESTUARIOS Y COMEDORES", descripcion = "OFICINAS, ALMACENES, VESTUARIOS Y COMEDORES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CISTERNA PROVISIONAL PARA AGUA", descripcion = "CISTERNA PROVISIONAL PARA AGUA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="INSTALACIONES PROVISIONALES DE AGUA Y DESAGÜE", descripcion = "INSTALACIONES PROVISIONALES DE AGUA Y DESAGÜE", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="BAÑOS PORTATILES", descripcion = "BAÑOS PORTATILES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="INSTALACIONES PROVISIONALES DE ENEGÍA ELÉCTRICA", descripcion = "INSTALACIONES PROVISIONALES DE ENEGÍA ELÉCTRICA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="ELECTRICIDAD PARA LA CONSTRUCCION", descripcion = "ELECTRICIDAD PARA LA CONSTRUCCION", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="AGUA PARA LA CONSTRUCCION", descripcion = "AGUA PARA LA CONSTRUCCION", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="INSTALACIÓN TELEFÓNICA Y COMUNICACIÓN PROVISIONAL", descripcion = "INSTALACIÓN TELEFÓNICA Y COMUNICACIÓN PROVISIONAL", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="DADOS DE CONCRETO", descripcion = "DADOS DE CONCRETO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="PROTECCIÓN A VECINOS", descripcion = "PROTECCIÓN A VECINOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="M0VILIZACION Y DESMOVILIZACION EQUIPO Y HERRAMIENTAS", descripcion = "M0VILIZACION Y DESMOVILIZACION EQUIPO Y HERRAMIENTAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="ALQUILER DE GRÚA TORRE (INCL. MOVILIZACIÓN Y DESMOVILIZACIÓN, ASÍ COMO MONTAJE Y DESMONTAJE)", descripcion = "ALQUILER DE GRÚA TORRE (INCL. MOVILIZACIÓN Y DESMOVILIZACIÓN, ASÍ COMO MONTAJE Y DESMONTAJE)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="ALQUILER ELEVADOR - WINCHES", descripcion = "ALQUILER ELEVADOR - WINCHES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="GRUPO ELECTRÓGENO PROVISIONAL (ALQUILER Y CONSUMO COMBUSTIBLE)", descripcion = "GRUPO ELECTRÓGENO PROVISIONAL (ALQUILER Y CONSUMO COMBUSTIBLE)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="EQUIPOS MENORES (EQUIPO DE APOYO PARA MOVIMIENTO DE TIERRAS)", descripcion = "EQUIPOS MENORES (EQUIPO DE APOYO PARA MOVIMIENTO DE TIERRAS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="ANDAMIOS", descripcion = "ANDAMIOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="RETIRO DE ESCOMBROS", descripcion = "RETIRO DE ESCOMBROS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="LIMPIEZA FINAL DE OBRA Y ELIMINACION DE RESIDUOS", descripcion = "LIMPIEZA FINAL DE OBRA Y ELIMINACION DE RESIDUOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="ACARREO HORIZONTAL DE MATERIALES DE CONSTRUCCIÓN", descripcion = "ACARREO HORIZONTAL DE MATERIALES DE CONSTRUCCIÓN", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="AGUA EN BIDONES PARA EL PERSONAL OBRERO", descripcion = "AGUA EN BIDONES PARA EL PERSONAL OBRERO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="LEVANTAMIENTO E INSPECCIÓN DE INMUEBLES VECINOS", descripcion = "LEVANTAMIENTO E INSPECCIÓN DE INMUEBLES VECINOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },


                new Partida {  nombre ="DUCHAS PORTATILES", descripcion = "DUCHAS PORTATILES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },
                new Partida {  nombre ="LAVATORIOS PORTATILES", descripcion = "LAVATORIOS PORTATILES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "mes").unidadMedidaId },



                new Partida {  nombre ="DEMOLICION DE VEREDAS", descripcion = "DEMOLICION DE VEREDAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ELIMINACIÓN PROVENIENTE DE DEMOLICIÓN", descripcion = "ELIMINACIÓN PROVENIENTE DE DEMOLICIÓN", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },


                new Partida {  nombre ="EXCAVACION MASIVA", descripcion = "EXCAVACION MASIVA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="EXCAVACION LOCALIZADA", descripcion = "EXCAVACION LOCALIZADA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="DESQUINCHE Y ESTABILIZACIÓN DE TALUD", descripcion = "DESQUINCHE Y ESTABILIZACIÓN DE TALUD", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="RELLENO COMPACTADO CON MATERIAL PROPIO EN RAMPAS", descripcion = "RELLENO COMPACTADO CON MATERIAL PROPIO EN RAMPAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="RELLENO CON MAT. PRESTAMO (E= 15cm) P.M. al 95% EN ZAPATAS", descripcion = "RELLENO CON MAT. PRESTAMO (E= 15cm) P.M. al 95% EN ZAPATAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="ELIMINACION DE EXCEDENTES DE OBRA", descripcion = "ELIMINACION DE EXCEDENTES DE OBRA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="AFIRMADO, INCLUYE COMPACTACIÓN - PAVIMENTOS EN SÓTANO", descripcion = "AFIRMADO, INCLUYE COMPACTACIÓN - PAVIMENTOS EN SÓTANO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="PRUEBAS DE COMPACTACIÓN", descripcion = "PRUEBAS DE COMPACTACIÓN", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },

                new Partida {  nombre ="DEMOLICION DE CIMENTACION EXISTENTE", descripcion = "DEMOLICION DE CIMENTACION EXISTENTE", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },



                new Partida {  nombre ="SOLADO PARA ZAPATAS CONCRETO 1:12 E=2'", descripcion = "SOLADO PARA ZAPATAS CONCRETO 1:12 E=2'", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CIMIENTO ESCALONADO CONCRETO; CEMENTO 1:12 + P.G. (6' MAX).", descripcion = "CIMIENTO ESCALONADO CONCRETO; CEMENTO 1:12 + P.G. (6' MAX).", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },

                new Partida {  nombre ="CALZADURA ESCALONADA F'c 100kg/cm2", descripcion = "CALZADURA ESCALONADA F'c 100kg/cm2", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO DE CALZADURA", descripcion = "ENCOFRADO DE CALZADURA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CONTRAPISO MORTERO 1:6, e = 0.05 m", descripcion = "CONTRAPISO MORTERO 1:6, e = 0.05 m", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },


                new Partida {  nombre ="PERFILADO DE BANQUETAS Y ACARREO DE MATERIAL", descripcion = "PERFILADO DE BANQUETAS Y ACARREO DE MATERIAL", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PAÑETEO DE TALUD PERFILADO, CON PASTA AGUA-CEMENTO", descripcion = "PAÑETEO DE TALUD PERFILADO, CON PASTA AGUA-CEMENTO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="NIVELACIÓN DE TERRENO PARA BASE DE SOLADO DE MUROS", descripcion = "NIVELACIÓN DE TERRENO PARA BASE DE SOLADO DE MUROS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TUBERÍA PVC 150MM (6') PARA PASES DE ANCLAJES EN ENCOFRADOS", descripcion = "TUBERÍA PVC 150MM (6') PARA PASES DE ANCLAJES EN ENCOFRADOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m").unidadMedidaId },
                new Partida {  nombre ="PERFORACIONES, INYECCIONES, SUMINISTRO DE ANCLAJES, CABLES, TENSIONADO Y DES TENSIONADO DE CABLES, INCLUYE DIRECCIÓN TÉCNICA DE ANCLAJES POSTENSADOS.", descripcion = "PERFORACIONES, INYECCIONES, SUMINISTRO DE ANCLAJES, CABLES, TENSIONADO Y DES TENSIONADO DE CABLES, INCLUYE DIRECCIÓN TÉCNICA DE ANCLAJES POSTENSADOS.", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="CONCRETO PARA MURO ANCLADO", descripcion = "CONCRETO PARA MURO ANCLADO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO Y DESENCOFRADO.", descripcion = "ENCOFRADO Y DESENCOFRADO.", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PICADO DE CUÑAS DE VACIADO EN MUROS ANCLADOS", descripcion = "PICADO DE CUÑAS DE VACIADO EN MUROS ANCLADOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="DESQUINCHE DE CIMENTACIÓN", descripcion = "DESQUINCHE DE CIMENTACIÓN", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ACERO CORRUGADO FY= 4200 KG/CM2 GRADO 60", descripcion = "ACERO CORRUGADO FY= 4200 KG/CM2 GRADO 60", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="CURADO HÚMEDO EN MUROS ( CURADOR )", descripcion = "CURADO HÚMEDO EN MUROS ( CURADOR )", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PICADO DE MURO PARA ADHERENCIA", descripcion = "PICADO DE MURO PARA ADHERENCIA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="EXCAVACION MANUAL PARA TRASLAPE DE ACERO", descripcion = "EXCAVACION MANUAL PARA TRASLAPE DE ACERO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="PICADO CONCRETO PRODUCTO DE CACHIMBA DEJADA PARA REBASES", descripcion = "PICADO CONCRETO PRODUCTO DE CACHIMBA DEJADA PARA REBASES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO ADICIONAL PARA CACHIMBA", descripcion = "CONCRETO ADICIONAL PARA CACHIMBA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="ADITIVO PARA ADHERENCIA DE CONCRETO", descripcion = "ADITIVO PARA ADHERENCIA DE CONCRETO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADOS DE ADICIONALES POR BORDES POR PAÑOS", descripcion = "ENCOFRADOS DE ADICIONALES POR BORDES POR PAÑOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CONCRETO ADICIONAL PARA CAJUELAS DE ANCLAJES", descripcion = "CONCRETO ADICIONAL PARA CAJUELAS DE ANCLAJES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO ADICIONAL PARA CAJUELAS DE ANCLAJES", descripcion = "ENCOFRADO ADICIONAL PARA CAJUELAS DE ANCLAJES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ACERO FY=4200 KG/CM2 ADICIONAL PARA CAJUELAS DE ANCLAJES", descripcion = "ACERO FY=4200 KG/CM2 ADICIONAL PARA CAJUELAS DE ANCLAJES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },




                new Partida {  nombre ="ENCOFRADO Y DESENCOFRADO. - ZAPATAS Y COLUMNAS", descripcion = "ENCOFRADO Y DESENCOFRADO. - ZAPATAS Y COLUMNAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO Y DESENCOFRADO DE CIMIENTOS DE MURO", descripcion = "ENCOFRADO Y DESENCOFRADO DE CIMIENTOS DE MURO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO Y DESENCOFRADO. - PLACAS", descripcion = "ENCOFRADO Y DESENCOFRADO. - PLACAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO Y DESENCOFRADO. - COLUMNAS", descripcion = "ENCOFRADO Y DESENCOFRADO. - COLUMNAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO Y DESENCOFRADO DE COLUMNAS C/MADERA -AMARRE CERCO", descripcion = "ENCOFRADO Y DESENCOFRADO DE COLUMNAS C/MADERA -AMARRE CERCO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO Y DESENCOFRADO. - COLUMNETAS", descripcion = "ENCOFRADO Y DESENCOFRADO. - COLUMNETAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO Y DESENCOFRADO - LOSAS MACIZAS", descripcion = "ENCOFRADO Y DESENCOFRADO - LOSAS MACIZAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO Y DESENCOFRADO. - ESCALERAS", descripcion = "ENCOFRADO Y DESENCOFRADO. - ESCALERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO Y DESENCOFRADO. - VIGAS", descripcion = "ENCOFRADO Y DESENCOFRADO. - VIGAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO Y DESENCOFRADO - MUROS DE CISTERNAS Y CTO DE BOMBAS", descripcion = "ENCOFRADO Y DESENCOFRADO - MUROS DE CISTERNAS Y CTO DE BOMBAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO DE PAVIMENTOS EN SÓTANO", descripcion = "ENCOFRADO DE PAVIMENTOS EN SÓTANO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO Y DESENCOFRADO - LOSA DOBLE DIRECCIÓN", descripcion = "ENCOFRADO Y DESENCOFRADO - LOSA DOBLE DIRECCIÓN", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },


                new Partida {  nombre ="ENCOFRADO Y DESENCOFRADO. - VIGAS DE CIMENTACION", descripcion = "ENCOFRADO Y DESENCOFRADO. - VIGAS DE CIMENTACION", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO DE JARDINERAS", descripcion = "ENCOFRADO DE JARDINERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO PERDIDO DE LATERALES", descripcion = "ENCOFRADO PERDIDO DE LATERALES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO EN CAMARA DE DESAGUE", descripcion = "ENCOFRADO EN CAMARA DE DESAGUE", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCOFRADO ESPECIAL PARA CONCRETO EXPUESTO", descripcion = "ENCOFRADO ESPECIAL PARA CONCRETO EXPUESTO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },



                new Partida {  nombre ="ACERO -CIMIENTO DE MURO", descripcion = "ACERO -CIMIENTO DE MURO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - COLUMNAS DE AMARRE CERCO", descripcion = "ACERO - COLUMNAS DE AMARRE CERCO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - ZAPATAS Y COLUMNAS (SOLO ZAPATAS)", descripcion = "ACERO - ZAPATAS Y COLUMNAS (SOLO ZAPATAS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - PLACAS", descripcion = "ACERO - PLACAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - COLUMNAS", descripcion = "ACERO - COLUMNAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - COLUMNETAS", descripcion = "ACERO - COLUMNETAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - LOSAS MACIZAS", descripcion = "ACERO - LOSAS MACIZAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - ESCALERAS", descripcion = "ACERO - ESCALERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - VIGAS", descripcion = "ACERO - VIGAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - MUROS DE CISTERNAS Y CTO DE BOMBAS", descripcion = "ACERO - MUROS DE CISTERNAS Y CTO DE BOMBAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - LOSA DOBLE DIRECCIÓN", descripcion = "ACERO - LOSA DOBLE DIRECCIÓN", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - CAMARA DE DESAGUE", descripcion = "ACERO - CAMARA DE DESAGUE", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO EN SOBRE CIMIENTO", descripcion = "ACERO EN SOBRE CIMIENTO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },

                new Partida {  nombre ="ACERO - VIGA DE CIMENTACION", descripcion = "ACERO - VIGA DE CIMENTACION", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - MURO DE CONCRETO", descripcion = "ACERO - MURO DE CONCRETO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - FONDO DE CISTERNA", descripcion = "ACERO - FONDO DE CISTERNA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - PISCINA", descripcion = "ACERO - PISCINA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="ACERO - JARDINERA", descripcion = "ACERO - JARDINERA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },


                new Partida {  nombre ="CONCRETO F'C=210 kg/cm2 - ZAPATAS", descripcion = "CONCRETO F'C=210 kg/cm2 - ZAPATAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO F'c=210 kg/cm2 EN CIMIENTO DE MUROS", descripcion = "CONCRETO F'c=210 kg/cm2 EN CIMIENTO DE MUROS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO F'C=210 kg/cm2 - PLACAS", descripcion = "CONCRETO F'C=210 kg/cm2 - PLACAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO F'C=210 kg/cm2 - COLUMNAS", descripcion = "CONCRETO F'C=210 kg/cm2 - COLUMNAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO F'C=245 kg/cm2 - COLUMNAS", descripcion = "CONCRETO F'C=245 kg/cm2 - COLUMNAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO F'C=280 kg/cm2 - COLUMNAS", descripcion = "CONCRETO F'C=280 kg/cm2 - COLUMNAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO F'C=350 kg/cm2 - COLUMNAS", descripcion = "CONCRETO F'C=350 kg/cm2 - COLUMNAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO 210 KG/CM2, SIN BOMBA, DOSIF.EN OBRA - COLUMNAS DE AMARRE CERCO", descripcion = "CONCRETO 210 KG/CM2, SIN BOMBA, DOSIF.EN OBRA - COLUMNAS DE AMARRE CERCO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO F'C=210 kg/cm2 - COLUMNETAS", descripcion = "CONCRETO F'C=210 kg/cm2 - COLUMNETAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO F'C=210 kg/cm2 - LOSAS MACIZAS", descripcion = "CONCRETO F'C=210 kg/cm2 - LOSAS MACIZAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO F'C=210 kg/cm2 - ESCALERAS", descripcion = "CONCRETO F'C=210 kg/cm2 - ESCALERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO F'C=210 kg/cm2 - VIGAS", descripcion = "CONCRETO F'C=210 kg/cm2 - VIGAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO F'C=210 kg/cm2 - CON ADITIVO HIDROFUGO , CISTERNAS Y CTO DE BOMBAS", descripcion = "CONCRETO F'C=210 kg/cm2 - CON ADITIVO HIDROFUGO , CISTERNAS Y CTO DE BOMBAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO 210 KG/CM2, INCLUYE BOMBA,E=0.15m - PAVIMENTOS EN SÓTANO", descripcion = "CONCRETO 210 KG/CM2, INCLUYE BOMBA,E=0.15m - PAVIMENTOS EN SÓTANO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO 210 - LOSA DOBLE DIRECCIÓN", descripcion = "CONCRETO 210 - LOSA DOBLE DIRECCIÓN", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO DE SOBRE CIMIENTO 1 : 8 + 30% PM 6' MAXIMO", descripcion = "CONCRETO DE SOBRE CIMIENTO 1 : 8 + 30% PM 6' MAXIMO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO DE CAMARA DE DESAGUE F´C= 210 Kg/Cm2", descripcion = "CONCRETO DE CAMARA DE DESAGUE F´C= 210 Kg/Cm2", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CURADO HÚMEDO EN ZAPATAS MURO PANTALLA Y COLUMNAS", descripcion = "CURADO HÚMEDO EN ZAPATAS MURO PANTALLA Y COLUMNAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CURADO HÚMEDO EN CIMIENTOS DE MURO", descripcion = "CURADO HÚMEDO EN CIMIENTOS DE MURO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CURADO HUMEDO EN VIGAS DE CIMENTACION", descripcion = "CURADO HUMEDO EN VIGAS DE CIMENTACION", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CURADO CON ADITIVO - MURO DE CONCRETO", descripcion = "CURADO CON ADITIVO - MURO DE CONCRETO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CURADO CON ADITIVO EN PLACAS", descripcion = "CURADO CON ADITIVO EN PLACAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CURADO CON ADITIVO EN COLUMNAS", descripcion = "CURADO CON ADITIVO EN COLUMNAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CURADO HUMEDO DE COLUMNAS DE AMARRE CERCO", descripcion = "CURADO HUMEDO DE COLUMNAS DE AMARRE CERCO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CURADO HUMEDO DE COLUMNETAS", descripcion = "CURADO HUMEDO DE COLUMNETAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CURADO LOSAS MACIZAS (CURADOR) - LOSAS MACIZAS", descripcion = "CURADO LOSAS MACIZAS (CURADOR) - LOSAS MACIZAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CURADO CON ADITIVO EN ESCALERAS", descripcion = "CURADO CON ADITIVO EN ESCALERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CURADO - VIGAS", descripcion = "CURADO - VIGAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CURADO CON ADITIVO MUROS DE CISTERNAS Y CTO DE BOMBAS", descripcion = "CURADO CON ADITIVO MUROS DE CISTERNAS Y CTO DE BOMBAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CURADO HUMEDO DE PAVIMENTOS EN SÓTANO", descripcion = "CURADO HUMEDO DE PAVIMENTOS EN SÓTANO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CURADO LOSA DOBLE DIRECCIÓN", descripcion = "CURADO LOSA DOBLE DIRECCIÓN", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },

                new Partida {  nombre ="CONCRETO F'C=210 kg/cm2 - VIGAS DE CIMENTACION", descripcion = "CONCRETO F'C=210 kg/cm2 - VIGAS DE CIMENTACION", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO F'C=245 kg/cm2 - PLACAS", descripcion = "CONCRETO F'C=245 kg/cm2 - PLACAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO F'C=245 kg/cm2 - MUROS DE CISTERNA", descripcion = "CONCRETO F'C=245 kg/cm2 - MUROS DE CISTERNA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO 210 KG/CM2, INCLUYE BOMBA,E=0.20m - PAVIMENTOS EN SÓTANO", descripcion = "CONCRETO 210 KG/CM2, INCLUYE BOMBA,E=0.20m - PAVIMENTOS EN SÓTANO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CONCRETO PARA JARDINERAS C/N IMPERMEABILIZANTES", descripcion = "CONCRETO PARA JARDINERAS C/N IMPERMEABILIZANTES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="CURADO HÚMEDO EN JARDINERAS", descripcion = "CURADO HÚMEDO EN JARDINERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },



                new Partida {  nombre ="CONCRETO F'C=210 kg/cm2", descripcion = "CONCRETO F'C=210 kg/cm2", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="ACERO CORRUGADO FY= 4200 kg/cm2 GRADO 60", descripcion = "ACERO CORRUGADO FY= 4200 kg/cm2 GRADO 60", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="APUNTALAMIENTO Y DESENCOFRADO LOSA ALIGERADA", descripcion = "APUNTALAMIENTO Y DESENCOFRADO LOSA ALIGERADA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="SUMINISTRO DE VIGUETAS FIRTH Y BOVEDILLAS", descripcion = "SUMINISTRO DE VIGUETAS FIRTH Y BOVEDILLAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="CURADO CON ADITIVO LOSAS", descripcion = "CURADO CON ADITIVO LOSAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="LADRILLO DE TECHO ALIGERADO 30 x 30 x 20 cm", descripcion = "LADRILLO DE TECHO ALIGERADO 30 x 30 x 20 cm", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },




                new Partida {  nombre ="JUNTA DE TEKNOPORT E=2'", descripcion = "JUNTA DE TEKNOPORT E=2'", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="JUNTA DE AISLAMIENTO EN COLUMNAS", descripcion = "JUNTA DE AISLAMIENTO EN COLUMNAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m").unidadMedidaId },
                new Partida {  nombre ="JUNTA DE DILATACION", descripcion = "JUNTA DE DILATACION", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m").unidadMedidaId },
                new Partida {  nombre ="JUNTAS DE AISLAMIENTO EN MUROS", descripcion = "JUNTAS DE AISLAMIENTO EN MUROS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m").unidadMedidaId },
                new Partida {  nombre ="JUNTA DE CONSTRUCCION", descripcion = "JUNTA DE CONSTRUCCION", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m").unidadMedidaId },

                new Partida {  nombre ="JUNTA DE TEKNOPORT E=1'", descripcion = "JUNTA DE TEKNOPORT E=1'", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="JUNTA DE TEKNOPORT E=2'", descripcion = "JUNTA DE TEKNOPORT E=2'", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="JUNTA DE TEKNOPORT E=6'", descripcion = "JUNTA DE TEKNOPORT E=6'", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="JUNTA DE CONSTRUCCION (COLUMNAS)", descripcion = "JUNTA DE CONSTRUCCION (COLUMNAS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="COLUMNETAS", descripcion = "COLUMNETAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="VIGAS DE AMARRE", descripcion = "VIGAS DE AMARRE", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="DOWELL 3/4'", descripcion = "DOWELL 3/4'", unidadMedidaId = unidadMedida.Single(s => s.nombre == "kg").unidadMedidaId },
                new Partida {  nombre ="SUMINISTRO Y COLOCACION DE TUBO DE PVC PESADO D=1'", descripcion = "SUMINISTRO Y COLOCACION DE TUBO DE PVC PESADO D=1'", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },


                // ARQUITECTURA
                    
                new Partida {  nombre ="CABEZA ( 20 cm )", descripcion = "CABEZA ( 20 cm )", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CABEZA ( 25 cm )", descripcion = "CABEZA ( 25 cm )", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CABEZA ( 30 cm )", descripcion = "CABEZA ( 30 cm )", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CABEZA ( 35 cm )", descripcion = "CABEZA ( 35 cm )", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="SOGA (15 cm)", descripcion = "SOGA (15 cm)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="SOGA (10 cm)", descripcion = "SOGA (10 cm)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },


            

                new Partida {  nombre ="TARRAJEO CON IMPERMEABILIZANTE CISTERNA DE AGUA DE CONSUMO", descripcion = "TARRAJEO CON IMPERMEABILIZANTE CISTERNA DE AGUA DE CONSUMO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE JARDINES Y JARDINERAS CON IMPERMEABILIZANTE", descripcion = "TARRAJEO DE JARDINES Y JARDINERAS CON IMPERMEABILIZANTE", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE TABIQUERIA", descripcion = "TARRAJEO DE TABIQUERIA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE COLUMNAS Y PLACAS", descripcion = "TARRAJEO DE COLUMNAS Y PLACAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE VIGAS", descripcion = "TARRAJEO DE VIGAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO CIELO RASO SOTANOS", descripcion = "TARRAJEO CIELO RASO SOTANOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },

                new Partida {  nombre ="TARRAJEO DE TABIQUERIA", descripcion = "TARRAJEO DE TABIQUERIA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE COLUMNAS Y PLACAS", descripcion = "TARRAJEO DE COLUMNAS Y PLACAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE VIGAS", descripcion = "TARRAJEO DE VIGAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="VESTIDURA DE DERRAMES DE MAMPARAS PUERTAS Y VENTANAS", descripcion = "VESTIDURA DE DERRAMES DE MAMPARAS PUERTAS Y VENTANAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE CIELO RASO", descripcion = "TARRAJEO DE CIELO RASO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE FONDO DE ESCALERAS", descripcion = "TARRAJEO DE FONDO DE ESCALERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PULIDO DE GRADAS DE ESCALERA", descripcion = "PULIDO DE GRADAS DE ESCALERA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="BRUÑA ENCUENTRO MURO TECHO", descripcion = "BRUÑA ENCUENTRO MURO TECHO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="DOBLE TARRAJEO EN BAÑOS", descripcion = "DOBLE TARRAJEO EN BAÑOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CONCRETO EXPUESTO EN FACHADA", descripcion = "CONCRETO EXPUESTO EN FACHADA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="LADRILLO ROCOCHO EN FACHADA", descripcion = "LADRILLO ROCOCHO EN FACHADA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },

                new Partida {  nombre ="TARRAJEO DE MUROS INTERIORES", descripcion = "TARRAJEO DE MUROS INTERIORES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE MUROS EXTERIORES FACHADA", descripcion = "TARRAJEO DE MUROS EXTERIORES FACHADA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="VESTIDURA DE DERRAMES DE MAMPARAS PUERTAS Y VENTANAS", descripcion = "VESTIDURA DE DERRAMES DE MAMPARAS PUERTAS Y VENTANAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE CIELO RASO", descripcion = "TARRAJEO DE CIELO RASO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE FONDO DE ESCALERAS", descripcion = "TARRAJEO DE FONDO DE ESCALERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PULIDO DE GRADAS DE ESCALERA", descripcion = "PULIDO DE GRADAS DE ESCALERA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="BRUÑA ENCUENTRO MURO TECHO", descripcion = "BRUÑA ENCUENTRO MURO TECHO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="DOBLE TARRAJEO EN BAÑOS Y COCINAS", descripcion = "DOBLE TARRAJEO EN BAÑOS Y COCINAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },

                new Partida {  nombre ="BRUÑA ENCUENTRO PLACA - MURO (sotanos)", descripcion = "BRUÑA ENCUENTRO PLACA - MURO (sotanos)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE COLUMNAS Y PLACAS", descripcion = "TARRAJEO DE COLUMNAS Y PLACAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO CUARTO DE BOMBAS", descripcion = "TARRAJEO CUARTO DE BOMBAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE VIGAS Hmax=3.00m", descripcion = "TARRAJEO DE VIGAS Hmax=3.00m", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE COLUMNAS / TABIQUERÍA /PLACAS 3.00m< Hmax < 6.00m", descripcion = "TARRAJEO DE COLUMNAS / TABIQUERÍA /PLACAS 3.00m< Hmax < 6.00m", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO DE VIGAS y CIELO RASO 3.00m< Hmax < 6.00m", descripcion = "TARRAJEO DE VIGAS y CIELO RASO 3.00m< Hmax < 6.00m", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="TARRAJEO POBRE EN INTERIORES DE DUCTOS DE ALBAÑILERÍA", descripcion = "TARRAJEO POBRE EN INTERIORES DE DUCTOS DE ALBAÑILERÍA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="DOBLE TARRAJEO EN BAÑOS (h=0.35 m)", descripcion = "DOBLE TARRAJEO EN BAÑOS (h=0.35 m)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="REPARACION E IMPERMEABILIZACION DE PISCINAS", descripcion = "REPARACION E IMPERMEABILIZACION DE PISCINAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="REPARACION E IMPERMEABILIZACION DE CISTERNAS", descripcion = "REPARACION E IMPERMEABILIZACION DE CISTERNAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },


                new Partida {  nombre ="CUARTO DE BOMBAS", descripcion = "CUARTO DE BOMBAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CAJA DE ASCENSOR", descripcion = "CAJA DE ASCENSOR", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },

                new Partida {  nombre ="SOLAQUEO EN MUROS DE SÓTANO", descripcion = "SOLAQUEO EN MUROS DE SÓTANO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="SOLAQUEO DE COLUMNAS Y PLACAS SOTANOS", descripcion = "SOLAQUEO DE COLUMNAS Y PLACAS SOTANOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="SOLAQUEO DE MUROS POSTERIORES - EXTERIOR", descripcion = "SOLAQUEO DE MUROS POSTERIORES - EXTERIOR", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="BRUÑA EN MUROS LATERALES EXTERIORES", descripcion = "BRUÑA EN MUROS LATERALES EXTERIORES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="DOBLEZ EN VANOS (VOLTEO DE FILOS)", descripcion = "DOBLEZ EN VANOS (VOLTEO DE FILOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="MEDIA CAÑA EN JARDINERAS", descripcion = "MEDIA CAÑA EN JARDINERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },

                


                new Partida {  nombre ="PISO DE CEMENTO FROTACHADO SOTANOS (RAMPAS Y ESTACIONAMIENTOS )", descripcion = "PISO DE CEMENTO FROTACHADO SOTANOS (RAMPAS Y ESTACIONAMIENTOS )", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="BRUÑAS EN RAMPAS DE ESTACIONAMIENTO", descripcion = "BRUÑAS EN RAMPAS DE ESTACIONAMIENTO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="PISO DE CEMENTO PULIDO (Cuarto de bombas, depósitos, Cuarto de basura, Rack para bicicletas)", descripcion = "PISO DE CEMENTO PULIDO (Cuarto de bombas, depósitos, Cuarto de basura, Rack para bicicletas)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO MATE DE 60X60(Hall de ascensores)", descripcion = "PORCELANATO MATE DE 60X60(Hall de ascensores)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },

                new Partida {  nombre ="PISO PORCELANATO KLIPEN TREND BEIGE 0.60 X 0.60m (LOBBY Y SUM)", descripcion = "PISO PORCELANATO KLIPEN TREND BEIGE 0.60 X 0.60m (LOBBY Y SUM)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PISO DECORELA FUSION BLANCO 60 X 60 (HALL DE ASCENSORES)", descripcion = "PISO DECORELA FUSION BLANCO 60 X 60 (HALL DE ASCENSORES)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO KLIPEN BASALT GRIS RUSTICO DE 60 X 60(Ingreso Peatonal y patio interior)", descripcion = "PORCELANATO KLIPEN BASALT GRIS RUSTICO DE 60 X 60(Ingreso Peatonal y patio interior)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PISO DE CEMENTO FROTACHADO  (RAMPAS ACCESO VEHICULAR )", descripcion = "PISO DE CEMENTO FROTACHADO  (RAMPAS ACCESO VEHICULAR )", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO FUSION DECORELA FUSION 0.60 C0.60 m (BAÑOS, GIMNASIO, SALA DE NIÑOS, SUM)", descripcion = "PORCELANATO FUSION DECORELA FUSION 0.60 C0.60 m (BAÑOS, GIMNASIO, SALA DE NIÑOS, SUM)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="VINILICO EN ROLLOS(SALA DE NIÑOS)", descripcion = "VINILICO EN ROLLOS(SALA DE NIÑOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PISO DE CAUCHO (GIMNASIO)", descripcion = "PISO DE CAUCHO (GIMNASIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },


                new Partida {  nombre ="PISO LAMINADO KAINDL INFINITO ROBLE 193 X 1380X8MM (SALA COMEDOR, DORMITORIOS, PASADIZOS, CL, WCL)", descripcion = "PISO LAMINADO KAINDL INFINITO ROBLE 193 X 1380X8MM (SALA COMEDOR, DORMITORIOS, PASADIZOS, CL, WCL)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO SEMI GRES DECORELA FUSION GRIS 0.60 X 0.60 m(COCINA)", descripcion = "PORCELANATO SEMI GRES DECORELA FUSION GRIS 0.60 X 0.60 m(COCINA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CERAMICO DE 45 X 45 GRIS PLATA(LAVANDERIA, DORMITORIO  Y BAÑO DE SERVICIO)", descripcion = "CERAMICO DE 45 X 45 GRIS PLATA(LAVANDERIA, DORMITORIO  Y BAÑO DE SERVICIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO ALAPANA CLEVELAND TAUPE 23 X 120 CM(BAÑO PRINCIPAL Y SECUNDARIO)", descripcion = "PORCELANATO ALAPANA CLEVELAND TAUPE 23 X 120 CM(BAÑO PRINCIPAL Y SECUNDARIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO TIPO MADERA( BAÑO Y ESTAR AZOTEA)", descripcion = "PORCELANATO TIPO MADERA( BAÑO Y ESTAR AZOTEA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO RECTIFICADO DE 0.60 C0.60 m( BAÑO Y DORMITORIO DE SERVICIO)", descripcion = "PORCELANATO RECTIFICADO DE 0.60 C0.60 m( BAÑO Y DORMITORIO DE SERVICIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO KLIPEN BASALT GRIS RUSTICO DE 60 X 60CM (TERRAZA)", descripcion = "PORCELANATO KLIPEN BASALT GRIS RUSTICO DE 60 X 60CM (TERRAZA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCHAPE DE MADERA SHIHUAHUACO (ESCALERAS DUPLEX)", descripcion = "ENCHAPE DE MADERA SHIHUAHUACO (ESCALERAS DUPLEX)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },

                new Partida {  nombre ="ENCHAPE DE LADRILLO CARAVISTA EN FACHADA Y JARDINERAS", descripcion = "ENCHAPE DE LADRILLO CARAVISTA EN FACHADA Y JARDINERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO SEMI GRES DECORELA FUSION GRIS 0.60 X 0.60 m (PISO DE DUCHA DE BAÑO SECUNDARIO)", descripcion = "PORCELANATO SEMI GRES DECORELA FUSION GRIS 0.60 X 0.60 m (PISO DE DUCHA DE BAÑO SECUNDARIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },



                new Partida {  nombre ="CERAMICO NACIONAL(CUARTO DE BASURA H=1.50)", descripcion = "CERAMICO NACIONAL(CUARTO DE BASURA H=1.50)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },

                new Partida {  nombre ="INGRESO ENCHAPADO CON LADRILLO RUSTICO(FACHADA)", descripcion = "INGRESO ENCHAPADO CON LADRILLO RUSTICO(FACHADA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ENCHAPE DE MADERA( LOBBY)", descripcion = "ENCHAPE DE MADERA( LOBBY)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="ZOCALO CERAMICO BLANCO PULIDO DE 30 X 60( BAÑOS)", descripcion = "ZOCALO CERAMICO BLANCO PULIDO DE 30 X 60( BAÑOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="VINIL LG  PALACE(GIMNASIO)", descripcion = "VINIL LG  PALACE(GIMNASIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="JARDINERAS ENCHAPADAS CON IMITACION PIEDRA O TALAMOYE(en zona de ingreso)", descripcion = "JARDINERAS ENCHAPADAS CON IMITACION PIEDRA O TALAMOYE(en zona de ingreso)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },

                new Partida {  nombre ="PORCELANATO SEMI GRES DECORELA FUSION GRIS 60 X 60CM ( COCINA)", descripcion = "PORCELANATO SEMI GRES DECORELA FUSION GRIS 60 X 60CM ( COCINA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CERAMICA  KLIPEN CLASIC BLANCO BRILLANTE DE 30 X 60CM(ENTRE MUEBLE ALTO Y MUEBLE BAJO DE COCINA)", descripcion = "CERAMICA  KLIPEN CLASIC BLANCO BRILLANTE DE 30 X 60CM(ENTRE MUEBLE ALTO Y MUEBLE BAJO DE COCINA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CERAMICO ACABADO MATE de 30 x30(LAVANDERIA)", descripcion = "CERAMICO ACABADO MATE de 30 x30(LAVANDERIA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO ALAPANA CLEVELAND TAUPE DE 23 X 120 CM(BAÑO PRINCIPAL)", descripcion = "PORCELANATO ALAPANA CLEVELAND TAUPE DE 23 X 120 CM(BAÑO PRINCIPAL)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="MICROCEMENTO COLOR NOGAL(BAÑO PRINCIPAL)", descripcion = "MICROCEMENTO COLOR NOGAL(BAÑO PRINCIPAL)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO SEMI GRES DECORELA FUSION BEIGE DE 60 X 60CM  (BAÑO SECUNDARIO)", descripcion = "PORCELANATO SEMI GRES DECORELA FUSION BEIGE DE 60 X 60CM  (BAÑO SECUNDARIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CERAMICA  KLIPEN CLASIC BLANCO BRILLANTE DE 30 X 60CM(BAÑO SECUNDARIO)", descripcion = "CERAMICA  KLIPEN CLASIC BLANCO BRILLANTE DE 30 X 60CM(BAÑO SECUNDARIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="MAYOLICA BLANCA BRILLANTE DE 45 X 27CM(BAÑO DE SERVICIO)", descripcion = "MAYOLICA BLANCA BRILLANTE DE 45 X 27CM(BAÑO DE SERVICIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CERAMICO DE 30X 30 H=2.10m (PARED DE DUCHA- BAÑO DE SERVICIO)", descripcion = "CERAMICO DE 30X 30 H=2.10m (PARED DE DUCHA- BAÑO DE SERVICIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },


                new Partida {  nombre ="CEMENTO PULIDO H= 10CM(DEPOSITOS, CUARTO DE BOMBAS)", descripcion = "CEMENTO PULIDO H= 10CM(DEPOSITOS, CUARTO DE BOMBAS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO DECORELA FUSION H=10CM(Hall de ascensores)", descripcion = "PORCELANATO DECORELA FUSION H=10CM(Hall de ascensores)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="PISO PORCELANATO KLIPEN TREND BEIGE 60 X 60 CM  H=10CM ( LOBBY)", descripcion = "PISO PORCELANATO KLIPEN TREND BEIGE 60 X 60 CM  H=10CM ( LOBBY)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO TIPO PIZARRA RUSTICO H=10CM(Ingreso Peatonal, terraza y patio interior)", descripcion = "PORCELANATO TIPO PIZARRA RUSTICO H=10CM(Ingreso Peatonal, terraza y patio interior)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="CERAMICO DE 30 X60 DE H= 10CM( BAÑOS, GIMNASIO, SALA DE NIÑOS)", descripcion = "CERAMICO DE 30 X60 DE H= 10CM( BAÑOS, GIMNASIO, SALA DE NIÑOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },

                new Partida {  nombre ="MADERA  DE 3' DE ALTURA(SALA,DORMITORIOS, CL, WCL, HALL, PASADIZOS)", descripcion = "MADERA  DE 3' DE ALTURA(SALA,DORMITORIOS, CL, WCL, HALL, PASADIZOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="CERAMICA KLIPEN CLASSIC BLANCO BRILLANTE H=10CM (COCINA)", descripcion = "CERAMICA KLIPEN CLASSIC BLANCO BRILLANTE H=10CM (COCINA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="CERAMICA 44 X 44 H=10CM(LAVANDERIA)", descripcion = "CERAMICA 44 X 44 H=10CM(LAVANDERIA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="PORCELANATO ALAPANA CLEVELAND TAUPE H=10CM(BAÑO PRINCIPAL Y SECUNDARIO)", descripcion = "PORCELANATO ALAPANA CLEVELAND TAUPE H=10CM(BAÑO PRINCIPAL Y SECUNDARIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="CONTRAZOCALO DEL MISMO TIPO DEL PISO(BAÑO Y ESTARAZOTEA)", descripcion = "CONTRAZOCALO DEL MISMO TIPO DEL PISO(BAÑO Y ESTARAZOTEA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="CERAMICO DE 45 X 45CM DE H= 10CM( DORMITORIO Y BAÑO DE SERVICIO)", descripcion = "CERAMICO DE 45 X 45CM DE H= 10CM( DORMITORIO Y BAÑO DE SERVICIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="ZOCALOS DE MADERA 3' DE ALTURA  (ESCALERAS DUPLEX)", descripcion = "ZOCALOS DE MADERA 3' DE ALTURA  (ESCALERAS DUPLEX)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },

                new Partida {  nombre ="ENCHAPE DE LADRILLO CARAVISTA EN FACHADA Y JARDINERAS", descripcion = "ENCHAPE DE LADRILLO CARAVISTA EN FACHADA Y JARDINERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },



                new Partida {  nombre ="COUNTER RECEPCION", descripcion = "COUNTER RECEPCION", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="PUERTAS DE MELAMINE(DUCTOS DE IIEE E IISS)", descripcion = "PUERTAS DE MELAMINE(DUCTOS DE IIEE E IISS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="PUERTAS DE DEPOSITOS, GRUPO ELECTROGENO Y CUARTO DE TABLEROS, CUARTO DE BOMBAS", descripcion = "PUERTAS DE DEPOSITOS, GRUPO ELECTROGENO Y CUARTO DE TABLEROS, CUARTO DE BOMBAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO DE MADERA (PUERTA PRINCIPAL)", descripcion = "CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO DE MADERA (PUERTA PRINCIPAL)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA(DORMITORIO PRINCIPAL)", descripcion = "CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA(DORMITORIO PRINCIPAL)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (VESTIDOR)", descripcion = "CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (VESTIDOR)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (DORMITORIOS SECUNDARIOS)", descripcion = "CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (DORMITORIOS SECUNDARIOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="P-09 PUERTA CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA CON SISTEMA VAIVEN (COCINA)", descripcion = "P-09 PUERTA CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA CON SISTEMA VAIVEN (COCINA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (BAÑO PRINCIPAL)", descripcion = "CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (BAÑO PRINCIPAL)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANL DE ABEJA (BAÑOS SECUNDARIOS)", descripcion = "CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANL DE ABEJA (BAÑOS SECUNDARIOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (BAÑO DE VISITA AZOTEA)", descripcion = "CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (BAÑO DE VISITA AZOTEA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (BAÑO DE SERVICIO)", descripcion = "CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (BAÑO DE SERVICIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (DORMITORIO DE SERVICIO)", descripcion = "CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (DORMITORIO DE SERVICIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (LAVANDERIA)", descripcion = "CONTRAPLACADA MDF 4MM DE ESPESOR SOBRE BASTIDOR Y RELLENO TIPO PANAL DE ABEJA (LAVANDERIA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },




                new Partida {  nombre ="MUEBLE DE COCINA ALTO DE MELAMINE DE 18MM COLOR BLANCO CON PUERTAS DE VIDRIO PAVONADO DONDE CORRESPONDA Y PERFIL DE ALUMINIO", descripcion = "MUEBLE DE COCINA ALTO DE MELAMINE DE 18MM COLOR BLANCO CON PUERTAS DE VIDRIO PAVONADO DONDE CORRESPONDA Y PERFIL DE ALUMINIO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="MUEBLE BAJO DE MELAMINE DE 18MM DE ESPESOR COLOR BLANCO MATE", descripcion = "MUEBLE BAJO DE MELAMINE DE 18MM DE ESPESOR COLOR BLANCO MATE", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="Suministro e instalación de mueble para cocina Tipo X01 parte baja y alta en melamina de 18 mm. color blanco con tapacanto de 3 mm. Respaldo y fondos de cajón en melamina de 6 mm. color blanco. Zócalos en aglomerado tropical. Incluye correderas telescópicas, bisagras cangrejo aceradas, pistones elevadores, rejillas de aluminio y jaladores de aluminio corrido.", descripcion = "Suministro e instalación de mueble para cocina Tipo X01 parte baja y alta en melamina de 18 mm. color blanco con tapacanto de 3 mm. Respaldo y fondos de cajón en melamina de 6 mm. color blanco. Zócalos en aglomerado tropical. Incluye correderas telescópicas, bisagras cangrejo aceradas, pistones elevadores, rejillas de aluminio y jaladores de aluminio corrido.", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },



                new Partida {  nombre ="MUEBLE DE MELAMINE DE 18MM NOVOPAN LINO( BAÑO PRINCIPAL)", descripcion = "MUEBLE DE MELAMINE DE 18MM NOVOPAN LINO( BAÑO PRINCIPAL)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="MUEBLE DE MELAMINE DE 18MM COLOR BLANCO( BAÑO SECUNDARIO)", descripcion = "MUEBLE DE MELAMINE DE 18MM COLOR BLANCO( BAÑO SECUNDARIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="MUEBLE SUSPENDIDO INTERIOR EN MELAMINE BLANCO DE 18MM EXTERIOR ACABADO AL DUCO BLANCO REBAJE SUPERIOR COMO TIRADOR (BAÑO PRINCIPAL Y SECUNDARIO)", descripcion = "MUEBLE SUSPENDIDO INTERIOR EN MELAMINE BLANCO DE 18MM EXTERIOR ACABADO AL DUCO BLANCO REBAJE SUPERIOR COMO TIRADOR (BAÑO PRINCIPAL Y SECUNDARIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },



                new Partida {  nombre ="W.I.C.L DE MELAMINE DE 19MM CON CAJOMERAS Y REPISAS (DRMITORIO PRINCIPAL)", descripcion = "W.I.C.L DE MELAMINE DE 19MM CON CAJOMERAS Y REPISAS (DRMITORIO PRINCIPAL)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="CLOSET DE MELAMINE DE 19MM CON TIRADORES DE ACERO INOXIDABLE (DORMIT. PRINCIPLA, SECUNDARIOS U PASADIZOS)", descripcion = "CLOSET DE MELAMINE DE 19MM CON TIRADORES DE ACERO INOXIDABLE (DORMIT. PRINCIPLA, SECUNDARIOS U PASADIZOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },

                new Partida {  nombre ="W.I.C.L DE MELAMINE DE 19MM CON CAJOMERAS Y REPISAS, PUERTASDE MDF COLOR BLANCO (DORMITORIO PRINCIPAL)", descripcion = "W.I.C.L DE MELAMINE DE 19MM CON CAJOMERAS Y REPISAS, PUERTASDE MDF COLOR BLANCO (DORMITORIO PRINCIPAL)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CLOSET DE MELAMINE DE 19MM CON CAJOMERAS Y REPISAS, PUERTASDE MDF COLOR BLANCO (DORMITORIOS SECUNDARIOS)", descripcion = "CLOSET DE MELAMINE DE 19MM CON CAJOMERAS Y REPISAS, PUERTASDE MDF COLOR BLANCO (DORMITORIOS SECUNDARIOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },




                new Partida {  nombre ="TABLERO CUARZO BLANCO DE 2CM DE ESPESOR (BAÑO GIMNASIO Y SALA DE NIÑOS)", descripcion = "TABLERO CUARZO BLANCO DE 2CM DE ESPESOR (BAÑO GIMNASIO Y SALA DE NIÑOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },

                new Partida {  nombre ="TABLERO GRANITO SERENA (SAL Y PMIENTA) (cocina)", descripcion = "TABLERO GRANITO SERENA (SAL Y PMIENTA) (cocina)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="CUARZO BLANCO DE 2 CM (BAÑO PRINCIPAL, SECUNDARIO Y DE VISITA)", descripcion = "CUARZO BLANCO DE 2 CM (BAÑO PRINCIPAL, SECUNDARIO Y DE VISITA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },




                new Partida {  nombre ="BARANDAS METALICAS CON TUBO DE Fe DE Ø2' Y 04 TRAVESAÑOS DE Ø1' PINTADAS GLOSS BLANCO EN ESCALERA DE SERVICIO.", descripcion = "BARANDAS METALICAS CON TUBO DE Fe DE Ø2' Y 04 TRAVESAÑOS DE Ø1' PINTADAS GLOSS BLANCO EN ESCALERA DE SERVICIO.", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="BARANDAS METALICA Y CRISTAL TEMPLADO EN TERRAZA H= 1.10M", descripcion = "BARANDAS METALICA Y CRISTAL TEMPLADO EN TERRAZA H= 1.10M", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="BARANDA DE ACERO Ø 2' SOBRE CRISTAL TEMPLADO EN BALCONES EXTERIORES. INCLUYE CRISTAL TEMPLADO DE 10MM QUE VA EN UN ANCLAJE DE ALUMINIO EN U.", descripcion = "BARANDA DE ACERO Ø 2' SOBRE CRISTAL TEMPLADO EN BALCONES EXTERIORES. INCLUYE CRISTAL TEMPLADO DE 10MM QUE VA EN UN ANCLAJE DE ALUMINIO EN U.", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="BARANDAS ACERO INOXIDABLE EN ESCALERA DE INGRESO", descripcion = "BARANDAS ACERO INOXIDABLE EN ESCALERA DE INGRESO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="BARANDA DE CRISTAL TEMPLADO(ESCALERA DE DUPLEX)", descripcion = "BARANDA DE CRISTAL TEMPLADO(ESCALERA DE DUPLEX)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="BARANDA EN ZONA DE TANQUE DE GAS", descripcion = "BARANDA EN ZONA DE TANQUE DE GAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="PUERTA DE INGRESO VEHICULAR BATIENTE, INCLUYE SISTEMA DE BRAZO HIDRAULICO", descripcion = "PUERTA DE INGRESO VEHICULAR BATIENTE, INCLUYE SISTEMA DE BRAZO HIDRAULICO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="PUERTA METALICA CORTAFUEGO ( MÍNIMO 90 MINUTOS) (P7) (1.00x2.10) (CON BARRA ANTIPANICO Y BISAGRA CIERRAPUERTAS)", descripcion = "PUERTA METALICA CORTAFUEGO ( MÍNIMO 90 MINUTOS) (P7) (1.00x2.10) (CON BARRA ANTIPANICO Y BISAGRA CIERRAPUERTAS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CANTONERAS DE ALUMINIO PFK 042048 (FURUKAWA) EN ESCALERAS DE SERVICIO", descripcion = "CANTONERAS DE ALUMINIO PFK 042048 (FURUKAWA) EN ESCALERAS DE SERVICIO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="REJILLA Y SUMIDERO EN RAMPAS, TERRAZAS, DUCHAS Y PUERTA DE INGRESO A ESTACIONAMIENTOS", descripcion = "REJILLA Y SUMIDERO EN RAMPAS, TERRAZAS, DUCHAS Y PUERTA DE INGRESO A ESTACIONAMIENTOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="TABLERO DE INTERCOMUNICADOR EMPOTRADO", descripcion = "TABLERO DE INTERCOMUNICADOR EMPOTRADO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="ESCALERA DE GATO CISTERNAS", descripcion = "ESCALERA DE GATO CISTERNAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="VENTANA DE INSPECCION DE CISTERNA CON PLANCHA ESTRIADA 1/8' TIRADOR Y ESPIGA PARA CANDADO Y ANGULO DE Fe 2'x2'x1/4'", descripcion = "VENTANA DE INSPECCION DE CISTERNA CON PLANCHA ESTRIADA 1/8' TIRADOR Y ESPIGA PARA CANDADO Y ANGULO DE Fe 2'x2'x1/4'", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="REJILLA METALICA PARA CAJUELA DE REBOSE DE CISTERNA CON PLANCHA DE 1'x1/4' @ 1 1/2'", descripcion = "REJILLA METALICA PARA CAJUELA DE REBOSE DE CISTERNA CON PLANCHA DE 1'x1/4' @ 1 1/2'", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="BASE METALICA PARA ELECTROBOMBA", descripcion = "BASE METALICA PARA ELECTROBOMBA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="REJILLA DE INYECCION DE AIRE", descripcion = "REJILLA DE INYECCION DE AIRE", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="REJILLA EN PISO CUARTO TECNICO", descripcion = "REJILLA EN PISO CUARTO TECNICO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="REJILLA DUCTO DE VENTILACION", descripcion = "REJILLA DUCTO DE VENTILACION", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="BARANDAS METALICAS PINTADAS Ø 2' EN ESCALERA DE SERVICIO", descripcion = "BARANDAS METALICAS PINTADAS Ø 2' EN ESCALERA DE SERVICIO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="BARANDAS ACERO INOXIDABLE EN ESCALERA DE DUPLEX", descripcion = "BARANDAS ACERO INOXIDABLE EN ESCALERA DE DUPLEX", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="PUERTAS BATIENTES SOBRE RODAJES CON PISTONES OLEODINAMICOS EN INGRESO A RAMPA", descripcion = "PUERTAS BATIENTES SOBRE RODAJES CON PISTONES OLEODINAMICOS EN INGRESO A RAMPA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="VENTANAS DE INSPECCION EN CISTERNA (1.60 x 0.70 m)", descripcion = "VENTANAS DE INSPECCION EN CISTERNA (1.60 x 0.70 m)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PUERTA CORTAFUEGO CON BARRA ANTIPÁNICO DE ACERO Y CIERRAPUERTAS EN ESCALERAS (MÍNIMO 02 hr)", descripcion = "PUERTA CORTAFUEGO CON BARRA ANTIPÁNICO DE ACERO Y CIERRAPUERTAS EN ESCALERAS (MÍNIMO 02 hr)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CANTONERAS DE ALUMINIO EN ESCALERAS DE SERVICIO", descripcion = "CANTONERAS DE ALUMINIO EN ESCALERAS DE SERVICIO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="TOTEM ACERO INOXIDABLE PARA INTERCOMUNICADORES (1.60x0.30)", descripcion = "TOTEM ACERO INOXIDABLE PARA INTERCOMUNICADORES (1.60x0.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="ESCALERA DE ACCESO AL TECHO CON RESPALDAR METALICO DE PROTECCION", descripcion = "ESCALERA DE ACCESO AL TECHO CON RESPALDAR METALICO DE PROTECCION", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="VIGAS METALICAS PARA ASCENSORES", descripcion = "VIGAS METALICAS PARA ASCENSORES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="REJILLA REMOVIBLE CON PLANCHA (SUMIDERO SOTANOS)", descripcion = "REJILLA REMOVIBLE CON PLANCHA (SUMIDERO SOTANOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="BARANDA METALICA H= 1.10 m (TECHO)", descripcion = "BARANDA METALICA H= 1.10 m (TECHO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="FILTRO DE MALLA DE ALUMINIO PARA TOMA DE AIRE FRESCO 18' x 18'", descripcion = "FILTRO DE MALLA DE ALUMINIO PARA TOMA DE AIRE FRESCO 18' x 18'", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="REJILLA PARA DUCHAS DE ACERO INOX - L= 80 CM", descripcion = "REJILLA PARA DUCHAS DE ACERO INOX - L= 80 CM", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="REJILLA REMOVIBLE DE 0.20x2.00 m (SOTANOS)", descripcion = "REJILLA REMOVIBLE DE 0.20x2.00 m (SOTANOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="REJILLA REMOVIBLE DE 0.20x1.00 m (SOTANOS)", descripcion = "REJILLA REMOVIBLE DE 0.20x1.00 m (SOTANOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="REJILLA REMOVIBLE DE 0.20x3.25 m (SOTANOS)", descripcion = "REJILLA REMOVIBLE DE 0.20x3.25 m (SOTANOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="REJILLA REMOVIBLE DE 0.20x6.10 m (SOTANOS)", descripcion = "REJILLA REMOVIBLE DE 0.20x6.10 m (SOTANOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="TAPA METALICA DE INSPECCION 0.70X3.25m", descripcion = "TAPA METALICA DE INSPECCION 0.70X3.25m", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="TAPA METALICA DE INSPECCION 1.00X3.25m", descripcion = "TAPA METALICA DE INSPECCION 1.00X3.25m", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="VENTANAS DE INSPECCION EN CISTERNA (1.60 x 0.70 m)", descripcion = "VENTANAS DE INSPECCION EN CISTERNA (1.60 x 0.70 m)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="ESCALERA DE ACCESO A CISTERNAS (1.1/4x1.1/4' parantes y peldaños)", descripcion = "ESCALERA DE ACCESO A CISTERNAS (1.1/4x1.1/4' parantes y peldaños)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="ESCALERA DE ACCESO A AZOTEA (1.1/4x1.1/4' parantes y peldaños , 0.60x2.60m)", descripcion = "ESCALERA DE ACCESO A AZOTEA (1.1/4x1.1/4' parantes y peldaños , 0.60x2.60m)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="REJILLA REMOVIBLE DE 0.40x0.25 m (SOTANOS)", descripcion = "REJILLA REMOVIBLE DE 0.40x0.25 m (SOTANOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="REJILLA REMOVIBLE DE 0.70x0.25 m (SOTANOS)", descripcion = "REJILLA REMOVIBLE DE 0.70x0.25 m (SOTANOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="REJILLA REMOVIBLE DE 0.40x0.40 m (SOTANOS)", descripcion = "REJILLA REMOVIBLE DE 0.40x0.40 m (SOTANOS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="TAPA METALICA 1.00X1.20m (SUMIDEROS)", descripcion = "TAPA METALICA 1.00X1.20m (SUMIDEROS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="TAPA METALICA 0.80X1.20m (SUMIDEROS)", descripcion = "TAPA METALICA 0.80X1.20m (SUMIDEROS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="TAPA METALICA 0.30X0.60m (DESAGUE)", descripcion = "TAPA METALICA 0.30X0.60m (DESAGUE)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="PASAMANOS METALICAS PINTADAS Ø 1.1/2' EN ESCALERA DE SERVICIO", descripcion = "PASAMANOS METALICAS PINTADAS Ø 1.1/2' EN ESCALERA DE SERVICIO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="BARANDAS METALICAS PINTADAS Ø 1.1/2' EN ESCALERA DE SERVICIO", descripcion = "BARANDAS METALICAS PINTADAS Ø 1.1/2' EN ESCALERA DE SERVICIO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="RACKS PARA BICICLETAS", descripcion = "RACKS PARA BICICLETAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="PASAMANOS DE ACERO INOXIDABLE Ø 1.1/2' EN ESCALERA DUPLEX", descripcion = "PASAMANOS DE ACERO INOXIDABLE Ø 1.1/2' EN ESCALERA DUPLEX", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="CANAL U DE FACHADA PRINCIPAL (ACABADO GLOSS NEGRO)", descripcion = "CANAL U DE FACHADA PRINCIPAL (ACABADO GLOSS NEGRO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },


                new Partida {  nombre ="CERRADURA EMBUTIDA DE PINES PARA PUERTA PRINCIPÀL, MANIJA ACERO MACIZA (MODELO SF031) Y TIRADOR RECTO PESADO EUROINOX GRADO 304 (DH-14 SS-1712 128x220MM)", descripcion = "CERRADURA EMBUTIDA DE PINES PARA PUERTA PRINCIPÀL, MANIJA ACERO MACIZA (MODELO SF031) Y TIRADOR RECTO PESADO EUROINOX GRADO 304 (DH-14 SS-1712 128x220MM)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CERRADURA EMBUTIDA RECTA PESADA CON MANIJA ACERO MACIZA (MODELO SF031) DORMITORIO MARCA EUROINOX GRADO 304", descripcion = "CERRADURA EMBUTIDA RECTA PESADA CON MANIJA ACERO MACIZA (MODELO SF031) DORMITORIO MARCA EUROINOX GRADO 304", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CERRADURA EMBUTIDA RECTA PESADA CON MANIJA ACERO MACIZA (MODELO SF031) PARA BAÑOS MARCA EUROINOX GRADO 304", descripcion = "CERRADURA EMBUTIDA RECTA PESADA CON MANIJA ACERO MACIZA (MODELO SF031) PARA BAÑOS MARCA EUROINOX GRADO 304", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CERRADURA DE POMO PARA DEPÓSITOS MARCA EUROINOX", descripcion = "CERRADURA DE POMO PARA DEPÓSITOS MARCA EUROINOX", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="BISAGRAS EUROINOX GRADO 304 3 1/2' X 3 1/2''X2.5MM GRADO 304 (4 POR PUERTA)", descripcion = "BISAGRAS EUROINOX GRADO 304 3 1/2' X 3 1/2''X2.5MM GRADO 304 (4 POR PUERTA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CERRADURA ELECTRICA EN PUERTAS DE INGRESO A LOBBY", descripcion = "CERRADURA ELECTRICA EN PUERTAS DE INGRESO A LOBBY", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="BISAGRA VAIVEN DOBLE EFECTO DE ACERO INOX. PESADA (COCINA)", descripcion = "BISAGRA VAIVEN DOBLE EFECTO DE ACERO INOX. PESADA (COCINA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="SISTEMA PUERTA BATIENTE CON FRENO HIDRAULICO", descripcion = "SISTEMA PUERTA BATIENTE CON FRENO HIDRAULICO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="TOPE DE PUERTA MEDIA LUNA EUROINOX EN AREAS COMUNES", descripcion = "TOPE DE PUERTA MEDIA LUNA EUROINOX EN AREAS COMUNES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CIERRA PUERTA HIDRAULICO", descripcion = "CIERRA PUERTA HIDRAULICO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="CERRADURA EMBUTIDA DE PINES PARA PUERTA PRINCIPAL Y TIRADOR RECTO PESADO EUROINOX GRADO 304", descripcion = "CERRADURA EMBUTIDA DE PINES PARA PUERTA PRINCIPAL Y TIRADOR RECTO PESADO EUROINOX GRADO 304", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CERRADURA EMBUTIDA RECTA PESADA DORMITORIO MARCA EUROINOX GRADO 304", descripcion = "CERRADURA EMBUTIDA RECTA PESADA DORMITORIO MARCA EUROINOX GRADO 304", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CERRADURA EMBUTIDA RECTA PESADA PARA BAÑOS MARCA EUROINOX GRADO 304", descripcion = "CERRADURA EMBUTIDA RECTA PESADA PARA BAÑOS MARCA EUROINOX GRADO 304", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CERRADURA DE POMO PARA DEPÓSITOS MARCA EUROINOX", descripcion = "CERRADURA DE POMO PARA DEPÓSITOS MARCA EUROINOX", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CERRADURA DE POMO PARA ZONA ESCALERAS (ESPECIFICAR MARCA)", descripcion = "CERRADURA DE POMO PARA ZONA ESCALERAS (ESPECIFICAR MARCA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="BISAGRAS EUROINOX GRADO 304 3 1/2' x 3 1/2' x 2.5 mm GRADO 304 (4 POR PUERTA)", descripcion = "BISAGRAS EUROINOX GRADO 304 3 1/2' x 3 1/2' x 2.5 mm GRADO 304 (4 POR PUERTA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CERRADURA ELECTRICA EN PUERTAS DE INGRESO A LOBBY", descripcion = "CERRADURA ELECTRICA EN PUERTAS DE INGRESO A LOBBY", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="BISAGRA VAIVEN DOBLE EFECTO DE ACERO INOX PESADA (COCINA)", descripcion = "BISAGRA VAIVEN DOBLE EFECTO DE ACERO INOX PESADA (COCINA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="SISTEMA PUERTA CON CONTROL REMOTO INC. EQUIPO E INSTALACIÓN (INGRESO A RAMPAS)", descripcion = "SISTEMA PUERTA CON CONTROL REMOTO INC. EQUIPO E INSTALACIÓN (INGRESO A RAMPAS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="PUERTA VEHICULAR BATIENTE AUTOMATICA DE 2 HOJAS - puerta de garage de 2 hojas de 3.00 x 2.40m cada una en MDF de 9mm, con bastidor perimetral de tubo rectangular metalico de 40mm x 80 mm y elementos inteiores en tubo cuadrado de 1 1/2', terminadas en base zincromato y gloss blanco, instlaada. Ins sist de bisagras tipo rodajes, importadas para las 2 hojas, 2 brazos hidraulicos con centrales de comando y receptores independientes, 4 circuitos detectores, 51 transmisorres bicanales", descripcion = "PUERTA VEHICULAR BATIENTE AUTOMATICA DE 2 HOJAS - puerta de garage de 2 hojas de 3.00 x 2.40m cada una en MDF de 9mm, con bastidor perimetral de tubo rectangular metalico de 40mm x 80 mm y elementos inteiores en tubo cuadrado de 1 1/2', terminadas en base zincromato y gloss blanco, instlaada. Ins sist de bisagras tipo rodajes, importadas para las 2 hojas, 2 brazos hidraulicos con centrales de comando y receptores independientes, 4 circuitos detectores, 51 transmisorres bicanales", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="TOPE DE PUERTAS MEDIA LUNA", descripcion = "TOPE DE PUERTAS MEDIA LUNA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CIERRE PUERTA HIDRAULICO", descripcion = "CIERRE PUERTA HIDRAULICO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },



                new Partida {  nombre ="M-01 INGRESO LOBBY(5.50X3.45)", descripcion = "M-01 INGRESO LOBBY(5.50X3.45)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-02 ESTAR(3.55X2.20)", descripcion = "M-02 ESTAR(3.55X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 VENTANA BAÑOS VISITA Y SUM(0.30X0.40)", descripcion = "V-10 VENTANA BAÑOS VISITA Y SUM(0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-11 GIMNASIO Y SUM(3.40X2.20)", descripcion = "M-11 GIMNASIO Y SUM(3.40X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-09 SUM(3.85X2.20)", descripcion = "M-09 SUM(3.85X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-06 SALA DE NIÑOS(2.84X2.20)", descripcion = "M-06 SALA DE NIÑOS(2.84X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-03 SALA DE NIÑOS(3.00X2.20)", descripcion = "M-03 SALA DE NIÑOS(3.00X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CRISTAL SERIGRAFIADO HALL", descripcion = "CRISTAL SERIGRAFIADO HALL", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },

                new Partida {  nombre ="M-10 GYM (3.40X2.20)", descripcion = "M-10 GYM (3.40X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-1 CUARTO DE BOMBA Y CISTERNA", descripcion = "V-1 CUARTO DE BOMBA Y CISTERNA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="M-5 SALA (1.80X2.20)", descripcion = "M-5 SALA (1.80X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-4 COMEDOR(2.75x2.20)", descripcion = "M-4 COMEDOR(2.75x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-7 COCINA y LAVANDERIA (0.90x2.20)", descripcion = "M-7 COCINA y LAVANDERIA (0.90x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-11 COCINA(0.85x1.00)", descripcion = "V-11 COCINA(0.85x1.00)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-4 DORMITORIO DE SERVICIO(0.60x1.30)", descripcion = "V-4 DORMITORIO DE SERVICIO(0.60x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-8 TERRAZA(1.50x2.20)", descripcion = "M-8 TERRAZA(1.50x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE VISITA Y PRINCIPAL (0.30X0.40)", descripcion = "V-10 BAÑO DE VISITA Y PRINCIPAL (0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-05 HALL(1.34x1.30)", descripcion = "V-05 HALL(1.34x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-06 HALL(0.40x1.30)", descripcion = "V-06 HALL(0.40x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-08 BAÑO SECUNDARIO(0.92x0.40)", descripcion = "V-08 BAÑO SECUNDARIO(0.92x0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", descripcion = "V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-7 DORMITORIO SECUNDARIO 3(0.90x2.20)", descripcion = "M-7 DORMITORIO SECUNDARIO 3(0.90x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-12 DORMITORIO PRINCIPAL(1.80*2.20)", descripcion = "M-12 DORMITORIO PRINCIPAL(1.80*2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-9 BAÑO DE SERVICIO(0.40x0.40)", descripcion = "V-9 BAÑO DE SERVICIO(0.40x0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="M-13 SALA (2.85X2.20)", descripcion = "M-13 SALA (2.85X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-7 COCINA(0.90x2.20)", descripcion = "M-7 COCINA(0.90x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-03 COCINA(1.60x1.35)", descripcion = "V-03 COCINA(1.60x1.35)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-4 DORMITORIO DE SERVICIO(0.60x1.30)", descripcion = "V-4 DORMITORIO DE SERVICIO(0.60x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-2 LAVANDERIA(2.50X1.00)", descripcion = "V-2 LAVANDERIA(2.50X1.00)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-8 TERRAZA(1.50x2.20)", descripcion = "M-8 TERRAZA(1.50x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE VISITA Y PRINCIPAL (0.30X0.40)", descripcion = "V-10 BAÑO DE VISITA Y PRINCIPAL (0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-05 HALL(1.34x1.30)", descripcion = "V-05 HALL(1.34x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-06 HALL(0.40x1.30)", descripcion = "V-06 HALL(0.40x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-08 BAÑO SECUNDARIO(0.92x0.40)", descripcion = "V-08 BAÑO SECUNDARIO(0.92x0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", descripcion = "V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-7 DORMITORIO SECUNDARIO 3(0.90x2.20)", descripcion = "M-7 DORMITORIO SECUNDARIO 3(0.90x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-12 DORMITORIO PRINCIPAL(1.80*2.20)", descripcion = "M-12 DORMITORIO PRINCIPAL(1.80*2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-9 BAÑO DE SERVICIO(0.40x0.40)", descripcion = "V-9 BAÑO DE SERVICIO(0.40x0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="V-13 SALA (1.60X2.20)", descripcion = "V-13 SALA (1.60X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-4 COMEDOR(2.75x2.20)", descripcion = "M-4 COMEDOR(2.75x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-7 COCINA(0.90x2.20)", descripcion = "M-7 COCINA(0.90x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-11 COCINA(0.85x1.00)", descripcion = "V-11 COCINA(0.85x1.00)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-9 BAÑO DE SERVICIO(0.40x0.40)", descripcion = "V-9 BAÑO DE SERVICIO(0.40x0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-12 LAVANDERIA(1.75X1.00)", descripcion = "V-12 LAVANDERIA(1.75X1.00)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-4 DORMITORIO DE SERVICIO(0.60x1.30)", descripcion = "V-4 DORMITORIO DE SERVICIO(0.60x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-05 HALL(1.34x1.30)", descripcion = "V-05 HALL(1.34x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-06 HALL(0.40x1.30)", descripcion = "V-06 HALL(0.40x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-15 HALL(1.50x1.30)", descripcion = "V-15 HALL(1.50x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE VISITA Y PRINCIPAL (0.30X0.40)", descripcion = "V-10 BAÑO DE VISITA Y PRINCIPAL (0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-08 BAÑO SECUNDARIO(0.92x0.40)", descripcion = "V-08 BAÑO SECUNDARIO(0.92x0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", descripcion = "V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", descripcion = "V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-16 DORMITORIO PRINCIPAL(1.80X1.30))", descripcion = "V-16 DORMITORIO PRINCIPAL(1.80X1.30))", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="M-15 SALA COMEDOR(4.40x2.20)", descripcion = "M-15 SALA COMEDOR(4.40x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-14 COCINA(2.28x1.10)", descripcion = "V-14 COCINA(2.28x1.10)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE VISITA, SECUNDARIO Y SERVICIO (0.30X0.40)", descripcion = "V-10 BAÑO DE VISITA, SECUNDARIO Y SERVICIO (0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-24 DEPOSITO (1.15X0.40)", descripcion = "V-24 DEPOSITO (1.15X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-23 LAVANDERIA (0.50X1.30)", descripcion = "V-23 LAVANDERIA (0.50X1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", descripcion = "V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-21 BAÑO PRINCIPAL (0.80X0.40)", descripcion = "V-21 BAÑO PRINCIPAL (0.80X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", descripcion = "V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-19 DORMITORIO PRINCIPAL (2.40X1.30)", descripcion = "V-19 DORMITORIO PRINCIPAL (2.40X1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="V-20 DORMITORIO PRINCIPAL (0.25X1.90)", descripcion = "V-20 DORMITORIO PRINCIPAL (0.25X1.90)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-16 LAVANDERÍA /COCINA (0.80X2.20)", descripcion = "M-16 LAVANDERÍA /COCINA (0.80X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="M-15 SALA COMEDOR(4.40x2.20)", descripcion = "M-15 SALA COMEDOR(4.40x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-14 COCINA(2.28x1.10)", descripcion = "V-14 COCINA(2.28x1.10)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE VISITA, SECUNDARIO Y SERVICIO (0.30X0.40)", descripcion = "V-10 BAÑO DE VISITA, SECUNDARIO Y SERVICIO (0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-24 DEPOSITO (1.15X0.40)", descripcion = "V-24 DEPOSITO (1.15X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-23 LAVANDERIA (0.50X1.30)", descripcion = "V-23 LAVANDERIA (0.50X1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", descripcion = "V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-21 BAÑO PRINCIPAL (0.80X0.40)", descripcion = "V-21 BAÑO PRINCIPAL (0.80X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", descripcion = "V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-19 DORMITORIO PRINCIPAL (2.40X1.30)", descripcion = "V-19 DORMITORIO PRINCIPAL (2.40X1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="V-20 DORMITORIO PRINCIPAL (0.25X1.90)", descripcion = "V-20 DORMITORIO PRINCIPAL (0.25X1.90)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-16 LAVANDERÍA /COCINA (0.80X2.20)", descripcion = "M-16 LAVANDERÍA /COCINA (0.80X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="V-13 SALA (1.60X2.20)", descripcion = "V-13 SALA (1.60X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-4 COMEDOR(2.75x2.20)", descripcion = "M-4 COMEDOR(2.75x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-7 COCINA(0.90x2.20)", descripcion = "M-7 COCINA(0.90x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-11 COCINA(0.85x1.00)", descripcion = "V-11 COCINA(0.85x1.00)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-9 BAÑO DE SERVICIO(0.40x0.40)", descripcion = "V-9 BAÑO DE SERVICIO(0.40x0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-12 LAVANDERIA(1.75X1.00)", descripcion = "V-12 LAVANDERIA(1.75X1.00)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-4 DORMITORIO DE SERVICIO(0.60x1.30)", descripcion = "V-4 DORMITORIO DE SERVICIO(0.60x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-05 HALL(1.34x1.30)", descripcion = "V-05 HALL(1.34x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-06 HALL(0.40x1.30)", descripcion = "V-06 HALL(0.40x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-15 HALL(1.50x1.30)", descripcion = "V-15 HALL(1.50x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE VISITA Y PRINCIPAL (0.30X0.40)", descripcion = "V-10 BAÑO DE VISITA Y PRINCIPAL (0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-08 BAÑO SECUNDARIO(0.92x0.40)", descripcion = "V-08 BAÑO SECUNDARIO(0.92x0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", descripcion = "V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", descripcion = "V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-16 DORMITORIO PRINCIPAL(1.80X1.30))", descripcion = "V-16 DORMITORIO PRINCIPAL(1.80X1.30))", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="V-13 SALA (1.60X2.20)", descripcion = "V-13 SALA (1.60X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-4 COMEDOR(2.75x2.20)", descripcion = "M-4 COMEDOR(2.75x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-25 COCINA(1.45x1.00)", descripcion = "V-25 COCINA(1.45x1.00)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-05 HALL(1.34x1.30)", descripcion = "V-05 HALL(1.34x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-06 HALL(0.40x1.30)", descripcion = "V-06 HALL(0.40x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-15 HALL(1.50x1.30)", descripcion = "V-15 HALL(1.50x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE VISITA Y PRINCIPAL (0.30X0.40)", descripcion = "V-10 BAÑO DE VISITA Y PRINCIPAL (0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-08 BAÑO SECUNDARIO(0.92x0.40)", descripcion = "V-08 BAÑO SECUNDARIO(0.92x0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", descripcion = "V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", descripcion = "V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-16 DORMITORIO PRINCIPAL(1.80X1.30))", descripcion = "V-16 DORMITORIO PRINCIPAL(1.80X1.30))", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="M-15 SALA COMEDOR(4.40x2.20)", descripcion = "M-15 SALA COMEDOR(4.40x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-14 COCINA(2.28x1.10)", descripcion = "V-14 COCINA(2.28x1.10)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE VISITA Y SECUNDARIO (0.30X0.40)", descripcion = "V-10 BAÑO DE VISITA Y SECUNDARIO (0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", descripcion = "V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-21 BAÑO PRINCIPAL (0.80X0.40)", descripcion = "V-21 BAÑO PRINCIPAL (0.80X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", descripcion = "V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-19 DORMITORIO PRINCIPAL (2.40X1.30)", descripcion = "V-19 DORMITORIO PRINCIPAL (2.40X1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="V-20 DORMITORIO PRINCIPAL (0.25X1.90)", descripcion = "V-20 DORMITORIO PRINCIPAL (0.25X1.90)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-23 ESCALERA DUPLEX (0.50X.90)", descripcion = "V-23 ESCALERA DUPLEX (0.50X.90)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="M-15 SALA COMEDOR(4.40x2.20)", descripcion = "M-15 SALA COMEDOR(4.40x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-14 COCINA(2.28x1.10)", descripcion = "V-14 COCINA(2.28x1.10)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE VISITA Y SECUNDARIO (0.30X0.40)", descripcion = "V-10 BAÑO DE VISITA Y SECUNDARIO (0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", descripcion = "V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-21 BAÑO PRINCIPAL (0.80X0.40)", descripcion = "V-21 BAÑO PRINCIPAL (0.80X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", descripcion = "V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-19 DORMITORIO PRINCIPAL (2.40X1.30)", descripcion = "V-19 DORMITORIO PRINCIPAL (2.40X1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="V-20 DORMITORIO PRINCIPAL (0.25X1.90)", descripcion = "V-20 DORMITORIO PRINCIPAL (0.25X1.90)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-23 ESCALERA DUPLEX (0.50X.90)", descripcion = "V-23 ESCALERA DUPLEX (0.50X.90)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="V-13 SALA (1.60X2.20)", descripcion = "V-13 SALA (1.60X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-4 COMEDOR(2.75x2.20)", descripcion = "M-4 COMEDOR(2.75x2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-25 COCINA(1.45x1.00)", descripcion = "V-25 COCINA(1.45x1.00)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-05 HALL(1.34x1.30)", descripcion = "V-05 HALL(1.34x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-06 HALL(0.40x1.30)", descripcion = "V-06 HALL(0.40x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-15 HALL(1.50x1.30)", descripcion = "V-15 HALL(1.50x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE VISITA Y PRINCIPAL (0.30X0.40)", descripcion = "V-10 BAÑO DE VISITA Y PRINCIPAL (0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-08 BAÑO SECUNDARIO(0.92x0.40)", descripcion = "V-08 BAÑO SECUNDARIO(0.92x0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", descripcion = "V-07 DORMITORIO SECUNDARIO 2(1.20x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", descripcion = "V-17 DORMITORIO SECUNDARIO 3(0.90x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-16 DORMITORIO PRINCIPAL(1.80X1.30))", descripcion = "V-16 DORMITORIO PRINCIPAL(1.80X1.30))", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="PARAPETO H=0.70 +BARANDA", descripcion = "PARAPETO H=0.70 +BARANDA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="M-19 ESTAR (6.03X2.20)", descripcion = "M-19 ESTAR (6.03X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-26 BAR(1.20X1.00)", descripcion = "V-26 BAR(1.20X1.00)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-04 ESCALERA(0.60X1.30)", descripcion = "V-04 ESCALERA(0.60X1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE VISITA Y SERVICIO(0.30X0.40)", descripcion = "V-10 BAÑO DE VISITA Y SERVICIO(0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-17 DORMITORIO DE SERVICIO (0.90x1.30)", descripcion = "V-17 DORMITORIO DE SERVICIO (0.90x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-27 HALL(0.70x1.20)", descripcion = "V-27 HALL(0.70x1.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-17 TERRAZA (1.20X2.20)", descripcion = "M-17 TERRAZA (1.20X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="PARAPETO H=1.20", descripcion = "PARAPETO H=1.20", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="M-20 ESTAR (4.25X2.20)", descripcion = "M-20 ESTAR (4.25X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-21 ESTAR (0.60X2.20)", descripcion = "M-21 ESTAR (0.60X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-31 ESTAR (2.72X1.30)", descripcion = "V-31 ESTAR (2.72X1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-30 BAÑO SECUNDARIO(0.80X0.40)", descripcion = "V-30 BAÑO SECUNDARIO(0.80X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-18 TERRAZA (1.00X2.20)", descripcion = "M-18 TERRAZA (1.00X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE SERVICIO(0.30X0.40)", descripcion = "V-10 BAÑO DE SERVICIO(0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-29 DORMITORIO DE SERVICIO(0.70X1.30)", descripcion = "V-29 DORMITORIO DE SERVICIO(0.70X1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="PARAPETO H=1.20", descripcion = "PARAPETO H=1.20", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="M-20 ESTAR (4.25X2.20)", descripcion = "M-20 ESTAR (4.25X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-21 ESTAR (0.60X2.20)", descripcion = "M-21 ESTAR (0.60X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-31 ESTAR (2.72X1.30)", descripcion = "V-31 ESTAR (2.72X1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-30 BAÑO SECUNDARIO(0.80X0.40)", descripcion = "V-30 BAÑO SECUNDARIO(0.80X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-18 TERRAZA (1.00X2.20)", descripcion = "M-18 TERRAZA (1.00X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE SERVICIO(0.30X0.40)", descripcion = "V-10 BAÑO DE SERVICIO(0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-29 DORMITORIO DE SERVICIO(0.70X1.30)", descripcion = "V-29 DORMITORIO DE SERVICIO(0.70X1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="PARAPETO H=0.70 +BARANDA", descripcion = "PARAPETO H=0.70 +BARANDA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="M-19 ESTAR (6.03X2.20)", descripcion = "M-19 ESTAR (6.03X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-26 BAR(1.20X1.00)", descripcion = "V-26 BAR(1.20X1.00)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-04 ESCALERA(0.60X1.30)", descripcion = "V-04 ESCALERA(0.60X1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-10 BAÑO DE VISITA Y SERVICIO(0.30X0.40)", descripcion = "V-10 BAÑO DE VISITA Y SERVICIO(0.30X0.40)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-17 DORMITORIO DE SERVICIO (0.90x1.30)", descripcion = "V-17 DORMITORIO DE SERVICIO (0.90x1.30)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="V-27 HALL(0.70x1.20)", descripcion = "V-27 HALL(0.70x1.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="M-17 TERRAZA (1.20X2.20)", descripcion = "M-17 TERRAZA (1.20X2.20)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },



                new Partida {  nombre ="PINTURA NUMERACION EN ESTACIONAMIENTOS", descripcion = "PINTURA NUMERACION EN ESTACIONAMIENTOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="PINTURA EN SARDINEL Y DIVISION DE ESTACIONAMIENTO", descripcion = "PINTURA EN SARDINEL Y DIVISION DE ESTACIONAMIENTO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },

                new Partida {  nombre ="PINTURA LATEX BLANCO CIELO RASO (INCLUYE EMPASTE)", descripcion = "PINTURA LATEX BLANCO CIELO RASO (INCLUYE EMPASTE)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PINTURA SUPERMATE VENCEDOR 2 MANOS EN MUROS SOBRE PARED EMPASTADO (HALL)", descripcion = "PINTURA SUPERMATE VENCEDOR 2 MANOS EN MUROS SOBRE PARED EMPASTADO (HALL)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PINTURA DE TRAFICO EN PISTAS Y ESTACIONAMIENTOS", descripcion = "PINTURA DE TRAFICO EN PISTAS Y ESTACIONAMIENTOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },

                new Partida {  nombre ="PINTURA LATEX COLOR BLANCO EN SALA COMEDOR, DORMITORIOS, ESTAR, ESTUDIO, PASADIZOS", descripcion = "PINTURA LATEX COLOR BLANCO EN SALA COMEDOR, DORMITORIOS, ESTAR, ESTUDIO, PASADIZOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PINTURA LATEX COLOR BLANCO EN CIELO RASO EN SALA COMEDOR, DORMITORIOS, ESTAR, ESTUDIO, PASADIZOS", descripcion = "PINTURA LATEX COLOR BLANCO EN CIELO RASO EN SALA COMEDOR, DORMITORIOS, ESTAR, ESTUDIO, PASADIZOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PINTURA AL OLEO CIELO RASO (BAÑOS) (INCLUYE EMPASTE)", descripcion = "PINTURA AL OLEO CIELO RASO (BAÑOS) (INCLUYE EMPASTE)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="PINTURA LATEX EXTERIORES, 2 MANOS EN FACHADAS", descripcion = "PINTURA LATEX EXTERIORES, 2 MANOS EN FACHADAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },

                new Partida {  nombre ="Pintura de tuberias de montantes y colgadas en el sotano (latex)", descripcion = "Pintura de tuberias de montantes y colgadas en el sotano (latex)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="PINTURA DIVISION DE ESTACIONAMIENTO", descripcion = "PINTURA DIVISION DE ESTACIONAMIENTO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },



                new Partida {  nombre ="INODORO ONE PIECE TREBOL MODELO ADVANCE COLOR BLANCO (BAÑO LOBBY)", descripcion = "INODORO ONE PIECE TREBOL MODELO ADVANCE COLOR BLANCO (BAÑO LOBBY)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="OVALIN ADOSADO LAVATORIO KLIPEN BOREAL BLANCO(BAÑO LOBBY)", descripcion = "OVALIN ADOSADO LAVATORIO KLIPEN BOREAL BLANCO(BAÑO LOBBY)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="GRIFERÍA: PARA LAVATORIO, MARCA VAINSA MODELO MALI BARES CROMO DE 4” (BAÑO DE LOBBY)", descripcion = "GRIFERÍA: PARA LAVATORIO, MARCA VAINSA MODELO MALI BARES CROMO DE 4” (BAÑO DE LOBBY)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="INODORO ONE PIECE TREBOL MODELO ADVANCE COLOR BLANCO (BAÑO SUM)", descripcion = "INODORO ONE PIECE TREBOL MODELO ADVANCE COLOR BLANCO (BAÑO SUM)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="OVALIN ADOSADO LAVATORIO KLIPEN BOREAL BLANCO(BAÑO SUM)", descripcion = "OVALIN ADOSADO LAVATORIO KLIPEN BOREAL BLANCO(BAÑO SUM)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="GRIFERÍA: PARA LAVATORIO, MARCA VAINSA MODELO MALI BARES CROMO DE 4” (BAÑO DE SUM)", descripcion = "GRIFERÍA: PARA LAVATORIO, MARCA VAINSA MODELO MALI BARES CROMO DE 4” (BAÑO DE SUM)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="GRIFERÍA PARA LAVADERO DE KITCHENETTE (SUM)", descripcion = "GRIFERÍA PARA LAVADERO DE KITCHENETTE (SUM)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="POZA PARA LAVADERO DE KITCHENETTE (SUM)", descripcion = "POZA PARA LAVADERO DE KITCHENETTE (SUM)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="INSTALACION DE GRIFERIAS (Incluye accesorios)", descripcion = "INSTALACION DE GRIFERIAS (Incluye accesorios)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="INSTALACIÓN DE APARATOS SANITARIOS", descripcion = "INSTALACIÓN DE APARATOS SANITARIOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="INODORO ONE PIECE KLIPEN FREMONT II BLANCO (BAÑO PRINCIPAL Y SECUNDARIO)", descripcion = "INODORO ONE PIECE KLIPEN FREMONT II BLANCO (BAÑO PRINCIPAL Y SECUNDARIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="INODORO ONE PIECE KLIPEN NEW SIMPHONY BLANCO(BAÑO VISITAS)", descripcion = "INODORO ONE PIECE KLIPEN NEW SIMPHONY BLANCO(BAÑO VISITAS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="INODORO ITALGRIF-ARUBA CON ASIENTO BL COLOR BLANCO (BAÑO DE SERVICIO)", descripcion = "INODORO ITALGRIF-ARUBA CON ASIENTO BL COLOR BLANCO (BAÑO DE SERVICIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="LAVADERO PARA EMPOTRAR RECTANGULAR COLOR BLANCO KLIPEN SARATOGA 52X39X18cm (BAÑO PRINCIPAL Y SECUNDARIO)", descripcion = "LAVADERO PARA EMPOTRAR RECTANGULAR COLOR BLANCO KLIPEN SARATOGA 52X39X18cm (BAÑO PRINCIPAL Y SECUNDARIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="OVALIN ADOSADO LAVATORIO KLIPEN BOREAL BANCO(BAÑO VISITA)", descripcion = "OVALIN ADOSADO LAVATORIO KLIPEN BOREAL BANCO(BAÑO VISITA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="LAVATORIO INTALGRIF-ARUBA C/ REBOSE SP 4' BLANCO(BAÑO DE SERVICIO)", descripcion = "LAVATORIO INTALGRIF-ARUBA C/ REBOSE SP 4' BLANCO(BAÑO DE SERVICIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="LAVADERO PARA EMPOTRAR RECORD 1 poza (COCINA)", descripcion = "LAVADERO PARA EMPOTRAR RECORD 1 poza (COCINA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="LAVADERO MODELO AMAZONAS TREBOL COLOR BLANCO(LAVANDERIA)", descripcion = "LAVADERO MODELO AMAZONAS TREBOL COLOR BLANCO(LAVANDERIA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="POZA PARA LAVADERO DE KITCHENETTE (BAR EN DUPLEX)", descripcion = "POZA PARA LAVADERO DE KITCHENETTE (BAR EN DUPLEX)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="TINA DE FIBRA DE VIDRIO (BAÑO SECUNDARIO)", descripcion = "TINA DE FIBRA DE VIDRIO (BAÑO SECUNDARIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="GRIFERÍA MEZCLADORA PARA LAVATORIO MARCA VAINSA MODELO MINIMALISTA (BAÑO PRINCIPAL)", descripcion = "GRIFERÍA MEZCLADORA PARA LAVATORIO MARCA VAINSA MODELO MINIMALISTA (BAÑO PRINCIPAL)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="GRIFERIA MEZCLADORA PARA DUCHA VAINSA MINIMALISTA CON SALIDA ESPAÑOLA 40 cm DE PARED (BAÑO PRINCIPAL)", descripcion = "GRIFERIA MEZCLADORA PARA DUCHA VAINSA MINIMALISTA CON SALIDA ESPAÑOLA 40 cm DE PARED (BAÑO PRINCIPAL)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="GRIFERÍA MEZCLADORA PARA OVALIN VAINSA (BAÑO SECUNDARIO)", descripcion = "GRIFERÍA MEZCLADORA PARA OVALIN VAINSA (BAÑO SECUNDARIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="GRIFERIA DUCHA MEZCLADORA VAINSA MINIMALISTA (BAÑO SECUNDARIO)", descripcion = "GRIFERIA DUCHA MEZCLADORA VAINSA MINIMALISTA (BAÑO SECUNDARIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="GRIFERÍA MEZCLADORA PARA OVALIN VAINSA (BAÑO VISITA)", descripcion = "GRIFERÍA MEZCLADORA PARA OVALIN VAINSA (BAÑO VISITA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="GRIFERÍA: PARA LAVATORIO, OMEGA BAVARO 4'(BAÑO DE SERVICIO)", descripcion = "GRIFERÍA: PARA LAVATORIO, OMEGA BAVARO 4'(BAÑO DE SERVICIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="GRIFERÍA DUCHA: MEZCLADORA MARCA VAINSA MODELO MALI BARES CROMO DE 8” DE DOS LLAVES (Incluye REGADERA - BAÑO DE SERVICIO)", descripcion = "GRIFERÍA DUCHA: MEZCLADORA MARCA VAINSA MODELO MALI BARES CROMO DE 8” DE DOS LLAVES (Incluye REGADERA - BAÑO DE SERVICIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="GRIFERÍA VAINSA LLAVE PICO CROMADO A LA PARED (LAVANDERIA)", descripcion = "GRIFERÍA VAINSA LLAVE PICO CROMADO A LA PARED (LAVANDERIA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="GRIFERÍA: MEZCLADORA DE DOS LLAVES PARA LAVADERO, VAINSA MINIMALISTA COLECCIÓN LEVER(COCINA)", descripcion = "GRIFERÍA: MEZCLADORA DE DOS LLAVES PARA LAVADERO, VAINSA MINIMALISTA COLECCIÓN LEVER(COCINA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="GRIFERÍA PARA LAVADERO DE KITCHENETTE (BAR EN DUPLEX)", descripcion = "GRIFERÍA PARA LAVADERO DE KITCHENETTE (BAR EN DUPLEX)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="GRIFERÍA PARA TINA (BAÑO SECUNDARIO)", descripcion = "GRIFERÍA PARA TINA (BAÑO SECUNDARIO)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="INSTALACION DE GRIFERIAS (Incluye accesorios)", descripcion = "INSTALACION DE GRIFERIAS (Incluye accesorios)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="INSTALACIÓN DE APARATOS SANITARIOS (Incluye accesorios)", descripcion = "INSTALACIÓN DE APARATOS SANITARIOS (Incluye accesorios)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="INSTALACIÓN DE POZAS DE COCINA (Incluye accesorios)", descripcion = "INSTALACIÓN DE POZAS DE COCINA (Incluye accesorios)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="INSTALACIÓN DE TINA (Incluye accesorios)", descripcion = "INSTALACIÓN DE TINA (Incluye accesorios)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="ACCESORIOS DE BAÑOS COMUNES ( jabonera, toallero, papelera) marca trebol blanco (losa)", descripcion = "ACCESORIOS DE BAÑOS COMUNES ( jabonera, toallero, papelera) marca trebol blanco (losa)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="ACCESORIOS DE BAÑOS DE DEPARTAMENTOS ( jabonera, toallero, papelera) marca trebol blanco (losa)", descripcion = "ACCESORIOS DE BAÑOS DE DEPARTAMENTOS ( jabonera, toallero, papelera) marca trebol blanco (losa)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },





                new Partida {  nombre ="PORTARROLLOS", descripcion = "PORTARROLLOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="JABONERA MODELO SARA DE DECOR CENTER", descripcion = "JABONERA MODELO SARA DE DECOR CENTER", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="PAPELERA", descripcion = "PAPELERA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="GANCHO DOBLE", descripcion = "GANCHO DOBLE", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="ESPEJO BISELADO", descripcion = "ESPEJO BISELADO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="COLOCACION DE ACCESORIOS", descripcion = "COLOCACION DE ACCESORIOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="CAJAS PARA VALVULAS DE 1/2' Y 1' EN COCINAS BAÑOS Y AREAS COMUNES", descripcion = "CAJAS PARA VALVULAS DE 1/2' Y 1' EN COCINAS BAÑOS Y AREAS COMUNES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="TAPAS PLASTICAS BLANCAS PARA VALVULAS BAÑO", descripcion = "TAPAS PLASTICAS BLANCAS PARA VALVULAS BAÑO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="REJILLA DE PLASTICO BLANCA APERSIANADA(LAVANDERIA)", descripcion = "REJILLA DE PLASTICO BLANCA APERSIANADA(LAVANDERIA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="TERMA PARA BAÑO AREAS COMUNES DONDE CORRESPONDA", descripcion = "TERMA PARA BAÑO AREAS COMUNES DONDE CORRESPONDA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="BARRA Y CORTINA DE DUCHA DONDE CORRESPONDA", descripcion = "BARRA Y CORTINA DE DUCHA DONDE CORRESPONDA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },




                new Partida {  nombre ="SEÑALETICA VERTICAL Y EVACUACION (N°DE PISO, SEÑALIZACIÓN DE EXTINTORES,INGRESO, SALIDAS, ESCALERAS)", descripcion = "SEÑALETICA VERTICAL Y EVACUACION (N°DE PISO, SEÑALIZACIÓN DE EXTINTORES,INGRESO, SALIDAS, ESCALERAS)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="NUMERACIÓN METÁLICA EN CADA DEPARTAMENTO", descripcion = "NUMERACIÓN METÁLICA EN CADA DEPARTAMENTO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="EXTINTORES PQS DE 6KG", descripcion = "EXTINTORES PQS DE 6KG", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },




                new Partida {  nombre ="CENTRO PARA HALL COMUN Y VESTIBULO", descripcion = "CENTRO PARA HALL COMUN Y VESTIBULO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="BRAQUETE PARA ESCALERAS", descripcion = "BRAQUETE PARA ESCALERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CENTRO DE LUZ PARA ESCALERAS", descripcion = "CENTRO DE LUZ PARA ESCALERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="LUMINARIAS EN SÓTANOS FLUORESCENTES DOBLES BE 2x 36 w ARTEFACTO FLUORESCENTE LENOX", descripcion = "LUMINARIAS EN SÓTANOS FLUORESCENTES DOBLES BE 2x 36 w ARTEFACTO FLUORESCENTE LENOX", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="LUCES DE EMERGENCIA OPALUX DE 24 LEDS CON 2 FAROS", descripcion = "LUCES DE EMERGENCIA OPALUX DE 24 LEDS CON 2 FAROS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="INSTALACION DE LUCES DE EMERGENCIA", descripcion = "INSTALACION DE LUCES DE EMERGENCIA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="LUMINARIA LED DICROICA PARA LOBBY, HALL", descripcion = "LUMINARIA LED DICROICA PARA LOBBY, HALL", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CENTRO DE LUZ PARA LOBBY", descripcion = "CENTRO DE LUZ PARA LOBBY", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="BRAQUETE PARA TERRAZA", descripcion = "BRAQUETE PARA TERRAZA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CENTRO DE LUZ AZOTEA", descripcion = "CENTRO DE LUZ AZOTEA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },

                new Partida {  nombre ="LUCES DE EMERGENCIA LEGRAND", descripcion = "LUCES DE EMERGENCIA LEGRAND", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CENTRO DE LUZ PARA TERRAZA", descripcion = "CENTRO DE LUZ PARA TERRAZA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="INSTALACION DE LUMINARIAS", descripcion = "INSTALACION DE LUMINARIAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },



                new Partida {  nombre ="COBERTURA DE LADRILLO PASTELERO", descripcion = "COBERTURA DE LADRILLO PASTELERO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },




                new Partida {  nombre ="AREA VERDE (A NIVEL DE TIERRA DE CHACRA)", descripcion = "AREA VERDE (A NIVEL DE TIERRA DE CHACRA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="VEREDAS EXTERIORES", descripcion = "VEREDAS EXTERIORES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="REPARACION DE VEREDAS", descripcion = "REPARACION DE VEREDAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="SARDINELES PARA JARDIN", descripcion = "SARDINELES PARA JARDIN", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },

                new Partida {  nombre ="TIERRA DE CHACRA", descripcion = "TIERRA DE CHACRA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="GEOTEXTIL DE POLIPROPILENO", descripcion = "GEOTEXTIL DE POLIPROPILENO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="CAPA DRENANTE DE POLIESTIRENO (GRAVA)", descripcion = "CAPA DRENANTE DE POLIESTIRENO (GRAVA)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m3").unidadMedidaId },
                new Partida {  nombre ="PINTURA DE EMULSION ASFALTICA", descripcion = "PINTURA DE EMULSION ASFALTICA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="MANTO ASFALTICO IMPERMEABLE", descripcion = "MANTO ASFALTICO IMPERMEABLE", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },


                new Partida {  nombre ="FALSO CIELO RASO DE DRYWALL (Recepción, Lobby, usos múltiples y juego de niños)", descripcion = "FALSO CIELO RASO DE DRYWALL (Recepción, Lobby, usos múltiples y juego de niños)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="DRYWALL EN PUERTAS ASCENSORES (H=2.70M)", descripcion = "DRYWALL EN PUERTAS ASCENSORES (H=2.70M)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="PROTECCIONES EN COLUMNAS EN ESTACIONAMIENTO DE JEBE CON CINTA REFLEXIVA (redondeados de 80 cm de altura x 10 cm de lados y 8mm BIZCOM)", descripcion = "PROTECCIONES EN COLUMNAS EN ESTACIONAMIENTO DE JEBE CON CINTA REFLEXIVA (redondeados de 80 cm de altura x 10 cm de lados y 8mm BIZCOM)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="ESPEJOS CONVEXOS ESTACIONAMIENTOS", descripcion = "ESPEJOS CONVEXOS ESTACIONAMIENTOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="SISTEMA DE CCTV", descripcion = "SISTEMA DE CCTV", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="CERCO SISTEMA LASER SEGURIDAD", descripcion = "CERCO SISTEMA LASER SEGURIDAD", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="ESPEJOS CONVEXOS ESTACIONAMIENTOS", descripcion = "ESPEJOS CONVEXOS ESTACIONAMIENTOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "glb").unidadMedidaId },
                new Partida {  nombre ="ALARMA SIRENA EXTERIORES", descripcion = "ALARMA SIRENA EXTERIORES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CONTROLES REMOTO PARA INGRESO VEHICULAR UNO POR CADA ESTACIONAMIENTO", descripcion = "CONTROLES REMOTO PARA INGRESO VEHICULAR UNO POR CADA ESTACIONAMIENTO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="TAPA DE CONCRETO 0 EN CAMARA DE BOMBEO DESAGUES", descripcion = "TAPA DE CONCRETO 0 EN CAMARA DE BOMBEO DESAGUES", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="SARDINEL PARA DUCHAS 0.10x0.10M", descripcion = "SARDINEL PARA DUCHAS 0.10x0.10M", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="SARDINEL DE CONCRETO EN FACHADA", descripcion = "SARDINEL DE CONCRETO EN FACHADA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="DERRAME DE HORNACINA EN SH PRINCIPAL Y SECUNDARIO", descripcion = "DERRAME DE HORNACINA EN SH PRINCIPAL Y SECUNDARIO", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },
                new Partida {  nombre ="GEOMEMBRANA DE POLIETILENO PVC 0.75MM EN JARDINERAS", descripcion = "GEOMEMBRANA DE POLIETILENO PVC 0.75MM EN JARDINERAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "m2").unidadMedidaId },
                new Partida {  nombre ="DINTELES EN VANOS", descripcion = "DINTELES EN VANOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "ml").unidadMedidaId },

                new Partida {  nombre ="TAPAS DE CONCRETO 0.30X0.60 (DESAGUE)", descripcion = "TAPAS DE CONCRETO 0.30X0.60 (DESAGUE)", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="TAPAS PARA VALVULAS BAÑOS Y COCINA", descripcion = "TAPAS PARA VALVULAS BAÑOS Y COCINA", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="CAJAS DE LLAVES PARA BAÑOS Y COCINAS", descripcion = "CAJAS DE LLAVES PARA BAÑOS Y COCINAS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },
                new Partida {  nombre ="EXTINTORES DE 6 KILOS", descripcion = "EXTINTORES DE 6 KILOS", unidadMedidaId = unidadMedida.Single(s => s.nombre == "und").unidadMedidaId },


            };

            partidas.ForEach(s => context.Partida.AddOrUpdate(p => p.nombre, s));
            context.SaveChanges();

            //var empresa = new List<Empresa>
            //{
            //    new Empresa {  nombre= "PISSANO SAC", ruc= "" },
            //    new Empresa { nombre= "SubContratos"}

            //};

            //tipoMaterial.ForEach(s => context.TipoMateriales.AddOrUpdate(p => p.nombre, s));
            //context.SaveChanges();



        }
    }
}

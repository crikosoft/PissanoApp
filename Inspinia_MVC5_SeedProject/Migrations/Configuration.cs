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
                new Titulo {  nombre ="TABLEROS", descripcion = "TABLEROS" },
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
                new Titulo {  nombre ="VARIOS", descripcion = "VARIOS" },
                new Titulo {  nombre ="GASTOS FINANCIEROS", descripcion = "GASTOS FINANCIEROS" }
                                 
            };


            titulo.ForEach(s => context.Titulo.AddOrUpdate(p => p.nombre, s));
            context.SaveChanges();



            var empresa = new List<Empresa>
            {
                new Empresa {  nombre= "PISSANO SAC", ruc= "" },
                new Empresa { nombre= "SubContratos"}

            };

            tipoMaterial.ForEach(s => context.TipoMateriales.AddOrUpdate(p => p.nombre, s));
            context.SaveChanges();



        }
    }
}

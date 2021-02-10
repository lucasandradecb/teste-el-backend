﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Teste.El.Backend.Domain.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MensagensInfo {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MensagensInfo() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Teste.El.Backend.Domain.Resources.MensagensInfo", typeof(MensagensInfo).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data de devolução não pode ser inferior a data de retirada..
        /// </summary>
        public static string Agendamento_DataDevMenorRet {
            get {
                return ResourceManager.GetString("Agendamento_DataDevMenorRet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data de retirada ou devolução não possuem valores válidos..
        /// </summary>
        public static string Agendamento_DatasInvalidas {
            get {
                return ResourceManager.GetString("Agendamento_DatasInvalidas", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OPS!!! Já existe um cliente cadastrado com o CPF informado..
        /// </summary>
        public static string Cliente_CpfExistente {
            get {
                return ResourceManager.GetString("Cliente_CpfExistente", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OPS!!! Já existe uma marca cadastrada com o código informado..
        /// </summary>
        public static string MarcaVeiculo_CodigoExistente {
            get {
                return ResourceManager.GetString("MarcaVeiculo_CodigoExistente", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OPS!!! Já existe um modelo cadastrado com o código informado..
        /// </summary>
        public static string ModeloVeiculo_CodigoExistente {
            get {
                return ResourceManager.GetString("ModeloVeiculo_CodigoExistente", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OPS!!! Já existe um operador cadastrado com a matrícula informada..
        /// </summary>
        public static string Operador_MatriculaExistente {
            get {
                return ResourceManager.GetString("Operador_MatriculaExistente", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OPS!!! Já existe um usuário cadastrado com a login informado..
        /// </summary>
        public static string Usuario_LoginExistente {
            get {
                return ResourceManager.GetString("Usuario_LoginExistente", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A marca informada para o veículo não está cadastrada. Por favor, cadastre antes de seguir o processo..
        /// </summary>
        public static string Veiculo_MarcaNaoCadastrada {
            get {
                return ResourceManager.GetString("Veiculo_MarcaNaoCadastrada", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O modelo informado para o veículo não está cadastrado. Por favor, cadastre antes de seguir o processo..
        /// </summary>
        public static string Veiculo_ModeloNaoCadastrado {
            get {
                return ResourceManager.GetString("Veiculo_ModeloNaoCadastrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OPS!!! Já existe um veículo cadastrado com a placa informada..
        /// </summary>
        public static string Veiculo_PlacaExistente {
            get {
                return ResourceManager.GetString("Veiculo_PlacaExistente", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Placa informada não pode ser nula ou vazia..
        /// </summary>
        public static string Veiculo_PlacaInvalida {
            get {
                return ResourceManager.GetString("Veiculo_PlacaInvalida", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não foi encontrado um veículo com a placa informada..
        /// </summary>
        public static string Veiculo_PlacaNaoEncontrada {
            get {
                return ResourceManager.GetString("Veiculo_PlacaNaoEncontrada", resourceCulture);
            }
        }
    }
}

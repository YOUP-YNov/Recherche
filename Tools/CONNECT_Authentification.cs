//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tools
{
    using System;
    using System.Collections.Generic;
    
    public partial class CONNECT_Authentification
    {
        public long Authentification_id { get; set; }
        public long Utilisateur_id { get; set; }
        public string Token { get; set; }
        public System.DateTime DateValidation { get; set; }
    
        public virtual UT_Utilisateur UT_Utilisateur { get; set; }
    }
}

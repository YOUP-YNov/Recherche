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
    
    public partial class HC_Connexion
    {
        public long Connexion_id { get; set; }
        public long Device_id { get; set; }
        public long Utilisateur_id { get; set; }
        public System.DateTime DateConnexion { get; set; }
    
        public virtual HC_Device HC_Device { get; set; }
        public virtual UT_Utilisateur UT_Utilisateur { get; set; }
    }
}
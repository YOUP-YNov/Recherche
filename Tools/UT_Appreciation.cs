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
    
    public partial class UT_Appreciation
    {
        public long Appreciation_id { get; set; }
        public long UtilisateurNote_id { get; set; }
        public long UtilisateurCommente_id { get; set; }
        public string Commentaire { get; set; }
        public short Note { get; set; }
    
        public virtual UT_Utilisateur UT_Utilisateur { get; set; }
        public virtual UT_Utilisateur UT_Utilisateur1 { get; set; }
    }
}
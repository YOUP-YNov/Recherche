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
    
    public partial class UT_Utilisateur_Aime_Categorie
    {
        public long Aime_id { get; set; }
        public long Utilisateur_id { get; set; }
        public long Categorie_id { get; set; }
    
        public virtual UT_Categorie UT_Categorie { get; set; }
        public virtual UT_Utilisateur UT_Utilisateur { get; set; }
    }
}

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
    
    public partial class HR_Historique
    {
        public long Historique_id { get; set; }
        public string MotsClefs { get; set; }
        public long Site_id { get; set; }
    
        public virtual HR_Site HR_Site { get; set; }
    }
}

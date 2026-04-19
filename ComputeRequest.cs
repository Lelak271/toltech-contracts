using System.Collections.Concurrent;

namespace Toltech.ComputeEngine.Contracts
{
    /// <summary>
    /// Représente les données d'entrée du moteur de calcul.
    /// Version compatible avec l'existant (pas de rupture).
    /// </summary>
    public sealed class ComputeRequest
    {
        /// <summary>
        /// Données du modèle (inchangé).
        /// </summary>
        public List<ComputeModelData> ModelData { get; init; } = new();

        /// <summary>
        /// Exigences à calculer (inchangé).
        /// </summary>
        public List<ComputeRequirement> Requirements { get; init; } = new();

        /// <summary>
        /// Id de la pièce fixée (optionnel).
        /// </summary>
        public int IdFixPart { get; init; } = 0;
    }

    /// <summary>
    /// Résultat du calcul Toltech.
    /// Version compatible avec l'existant.
    /// </summary>
    public sealed class ComputeResult
    {
        /// <summary>
        /// Indique si le calcul a réussi.
        /// </summary>
        public bool IsSuccess { get; init; }

        /// <summary>
        /// Résultats bruts du calcul (structure actuelle conservée).
        /// </summary>
        public ConcurrentDictionary<int, List<PrimaryResults>> Results { get; init; }
            = new();

        /// <summary>
        /// Message d'erreur éventuel.
        /// </summary>
        public string? ErrorMessage { get; init; }
    }


    // TO DO voir comment cette classe passe la frontiere dll de IcomputeEngine
    public sealed class PrimaryResults
    {
        public int IdData { get; set; }
        public double InflX { get; set; }
        public double InflY { get; set; }
        public double InflZ { get; set; }

    }

    public sealed class ComputeModelData
    {
        public int Id { get; init; }

        public int OriginePartId { get; init; }
        public int? ExtremitePartId { get; init; }

        public bool Active { get; init; }

        public double CoordX { get; init; }
        public double CoordY { get; init; }
        public double CoordZ { get; init; }

        public double CoordU { get; init; }
        public double CoordV { get; init; }
        public double CoordW { get; init; }

        public double TolOri { get; init; }
        public double TolInt { get; init; }
        public double TolExtr { get; init; }

        public int IdTolOri { get; init; }
        public int IdTolInt { get; init; }
        public int IdTolExtre { get; init; }

        public string? Model { get; init; }
    }

    public sealed class ComputeRequirement
    {
        public int Id_req { get; init; }

        public string? NameReq { get; init; }

        public double CoordX { get; init; }
        public double CoordY { get; init; }
        public double CoordZ { get; init; }

        public double CoordU { get; init; }
        public double CoordV { get; init; }
        public double CoordW { get; init; }

        public string? NameTolOri { get; init; }
        public string? NameTolExtre { get; init; }

        public string? Description1 { get; init; }
        public string? Description2 { get; init; }

        public string? Commentaire { get; init; }

        public double Tol1 { get; init; }
        public double Tol2 { get; init; }

        public int IdTol1 { get; init; }
        public int IdTol2 { get; init; }

        public bool CheckBox1 { get; init; }
        public bool CheckBox2 { get; init; }

        public int? PartReq1Id { get; init; }
        public int? PartReq2Id { get; init; }
    }

    /// <summary>
    /// Représente une pièce utilisée par le moteur de calcul Toltech.
    /// DTO pur, sans dépendance UI ou base de données.
    /// </summary>
    public sealed class ComputePart
    {
        public int Id { get; init; }

        public string? NamePart { get; init; }

        public double MasseVol { get; init; }

        public byte[]? ImagePart { get; init; }

        public string? Comment { get; init; }

        public bool IsFixed { get; init; }

        public bool IsActive { get; init; }
    }


}
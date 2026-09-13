using System.Collections.Concurrent;

namespace Toltech.Solver.Contracts
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
        public List<ComputeLinkage> ModelData { get; init; } = new();

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
        /// Stores the results of problem solving operations, indexed by an integer key of requirements.
        /// </summary>
        public ConcurrentDictionary<int, SolveResults> RawResults { get; init; } = new();

        /// <summary>
        /// Message d'erreur éventuel.
        /// </summary>
        public string? ErrorMessage { get; init; }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class DecompositionResults
    {
        public int IdData { get; set; }
        public UnknownType Type { get; set; }
        public double InflX { get; set; }
        public double InflY { get; set; }
        public double InflZ { get; set; }

    }

    /// <summary>
    /// Represents the results of a solving operation.
    /// </summary>
    public sealed class SolveResults
    {
        public List<DecompositionResults> Details { get; init; } = new();
    }


    #region Computes Datas

    /// <summary>
    /// DTO : Représente une liaison utilisée par le moteur de calcul Toltech.
    /// </summary>
    public sealed class ComputeLinkage
    {
        public int Id { get; init; }

        public int OriginePartId { get; init; }
        public int? ExtremitePartId { get; init; }


        public bool Active { get; init; }

        public double CoordX { get; init; }
        public double CoordY { get; init; }
        public double CoordZ { get; init; }
        public double CoordX2 { get; init; }
        public double CoordY2 { get; init; }
        public double CoordZ2 { get; init; }
        public double CoordU { get; init; }
        public double CoordV { get; init; }
        public double CoordW { get; init; }
        public double CoordU2 { get; init; }
        public double CoordV2 { get; init; }
        public double CoordW2 { get; init; }

        #region Tolérances
        // TODO tolerance



        #endregion


        public string? Name { get; init; }

        public LinkageType Linkage { get; init; }

        public ToleranceTriplet N { get; init; } = new();
        public ToleranceTriplet T1 { get; init; } = new();
        public ToleranceTriplet T2 { get; init; } = new();
        public ToleranceTriplet Rn { get; init; } = new();
        public ToleranceTriplet RT1 { get; init; } = new();
        public ToleranceTriplet RT2 { get; init; } = new();
    }

    /// <summary>
    /// DTO : Représente une exigence utilisée par le moteur de calcul Toltech.
    /// </summary>
    public sealed class ComputeRequirement
    {
        public int Id { get; init; }

        public string? Name { get; init; }

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
    /// DTO : Représente une pièce utilisée par le moteur de calcul Toltech.
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

    #region Helper for tolerances objects
   
    /// <summary>
    /// DTO : Représente les 3 tolérances d'un contact utilisée par le moteur de calcul Toltech.
    /// </summary>
    public class ToleranceTriplet
    {
        public ToleranceDefinition Origin { get; set; } = new();

        public ToleranceDefinition Intermediate { get; set; } = new();

        public ToleranceDefinition Extremity { get; set; } = new();
    }

    /// <summary>
    /// DTO : Représente une tolérance utilisée par le moteur de calcul Toltech.
    /// </summary>
    public sealed class ToleranceDefinition
    {
        public double Value { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public bool UseDatabase { get; set; }

        public int ToleranceId { get; set; }
    }
    #endregion

    #endregion

    #region General properties

    /// <summary>
    ///  
    /// </summary>
    public enum UnknownType
    {
        RotA,
        RotB,
        RotC,
        Tu,
        Tv,
        Tw
    }

    /// <summary>
    /// Types de liaison mécaniques possibles
    /// </summary>
    public enum LinkageType
    {
        PointContact = 0,       // Liaison ponctuelle
        LinearContact = 1,      // Liaison linéaire rectiligne
        AnnularContact = 2,     // Liaison linéaire annulaire
        PlanarContact = 3,      // Appui plan

        RevoluteContact = 4,    // Liaison pivot
        PrismaticContact = 5,   // Liaison glissière
        CylindricalContact = 6, // Liaison pivot glissant

        //HelicalContact = 7,   // Liaison hélicoïdale

        SphericalContact = 8,   // Liaison rotule

        //PinSlotContact = 9,   // Rotule à doigt

        FixedContact = 10,       // Liaison encastrement
        Requirement = 11       // Liaison encastrement
    }
   
    #endregion



}
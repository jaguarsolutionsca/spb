using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Usine] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Usine_Collection"/> class to do so.
	/// </summary>
	public sealed class Usine_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Usine_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Usine_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Usine_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Usine_Record(string connectionString, System.Data.SqlTypes.SqlString col_ID) {

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString == System.String.Empty) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString == System.String.Empty) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString != String.Empty) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Usine'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Usine", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ID = col_ID;
		}
		
		internal System.Data.SqlTypes.SqlString col_ID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ID {
		
			get {
			
				return(this.col_ID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ID = value;
				}
			}
		}
		
		internal bool col_DescriptionWasSet = false;
		private bool col_DescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Description = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Description {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Description);
			}
			set {
			
				this.col_DescriptionWasUpdated = true;
				this.col_DescriptionWasSet = true;
				this.col_Description = value;
			}
		}

		internal bool col_UtilisationIDWasSet = false;
		private bool col_UtilisationIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_UtilisationID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_UtilisationID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UtilisationID);
			}
			set {
			
				this.col_UtilisationIDWasUpdated = true;
				this.col_UtilisationIDWasSet = true;
				this.col_UtilisationID_Record = null;
				this.col_UtilisationID = value;
			}
		}

		
		private UsineUtilisation_Record col_UtilisationID_Record = null;
		public UsineUtilisation_Record Col_UtilisationID_UsineUtilisation_Record {
		
			get {

				if (this.col_UtilisationID_Record == null) {
				
					this.col_UtilisationID_Record = new UsineUtilisation_Record(this.connectionString, this.col_UtilisationID);
				}
				
				return(this.col_UtilisationID_Record);
			}
		}

		internal bool col_Paye_producteurWasSet = false;
		private bool col_Paye_producteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Paye_producteur = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Paye_producteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Paye_producteur);
			}
			set {
			
				this.col_Paye_producteurWasUpdated = true;
				this.col_Paye_producteurWasSet = true;
				this.col_Paye_producteur = value;
			}
		}

		internal bool col_Paye_transporteurWasSet = false;
		private bool col_Paye_transporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Paye_transporteur = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Paye_transporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Paye_transporteur);
			}
			set {
			
				this.col_Paye_transporteurWasUpdated = true;
				this.col_Paye_transporteurWasSet = true;
				this.col_Paye_transporteur = value;
			}
		}

		internal bool col_SpecificationWasSet = false;
		private bool col_SpecificationWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Specification = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Specification {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Specification);
			}
			set {
			
				this.col_SpecificationWasUpdated = true;
				this.col_SpecificationWasSet = true;
				this.col_Specification = value;
			}
		}

		internal bool col_Compte_a_recevoirWasSet = false;
		private bool col_Compte_a_recevoirWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_a_recevoir = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_a_recevoir {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Compte_a_recevoir);
			}
			set {
			
				this.col_Compte_a_recevoirWasUpdated = true;
				this.col_Compte_a_recevoirWasSet = true;
				this.col_Compte_a_recevoir_Record = null;
				this.col_Compte_a_recevoir = value;
			}
		}

		
		private Compte_Record col_Compte_a_recevoir_Record = null;
		public Compte_Record Col_Compte_a_recevoir_Compte_Record {
		
			get {

				if (this.col_Compte_a_recevoir_Record == null) {
				
					this.col_Compte_a_recevoir_Record = new Compte_Record(this.connectionString, this.col_Compte_a_recevoir);
				}
				
				return(this.col_Compte_a_recevoir_Record);
			}
		}

		internal bool col_Compte_ajustementWasSet = false;
		private bool col_Compte_ajustementWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_ajustement = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_ajustement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Compte_ajustement);
			}
			set {
			
				this.col_Compte_ajustementWasUpdated = true;
				this.col_Compte_ajustementWasSet = true;
				this.col_Compte_ajustement_Record = null;
				this.col_Compte_ajustement = value;
			}
		}

		
		private Compte_Record col_Compte_ajustement_Record = null;
		public Compte_Record Col_Compte_ajustement_Compte_Record {
		
			get {

				if (this.col_Compte_ajustement_Record == null) {
				
					this.col_Compte_ajustement_Record = new Compte_Record(this.connectionString, this.col_Compte_ajustement);
				}
				
				return(this.col_Compte_ajustement_Record);
			}
		}

		internal bool col_Compte_transporteurWasSet = false;
		private bool col_Compte_transporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_transporteur = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_transporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Compte_transporteur);
			}
			set {
			
				this.col_Compte_transporteurWasUpdated = true;
				this.col_Compte_transporteurWasSet = true;
				this.col_Compte_transporteur_Record = null;
				this.col_Compte_transporteur = value;
			}
		}

		
		private Compte_Record col_Compte_transporteur_Record = null;
		public Compte_Record Col_Compte_transporteur_Compte_Record {
		
			get {

				if (this.col_Compte_transporteur_Record == null) {
				
					this.col_Compte_transporteur_Record = new Compte_Record(this.connectionString, this.col_Compte_transporteur);
				}
				
				return(this.col_Compte_transporteur_Record);
			}
		}

		internal bool col_Compte_producteurWasSet = false;
		private bool col_Compte_producteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_producteur = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_producteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Compte_producteur);
			}
			set {
			
				this.col_Compte_producteurWasUpdated = true;
				this.col_Compte_producteurWasSet = true;
				this.col_Compte_producteur_Record = null;
				this.col_Compte_producteur = value;
			}
		}

		
		private Compte_Record col_Compte_producteur_Record = null;
		public Compte_Record Col_Compte_producteur_Compte_Record {
		
			get {

				if (this.col_Compte_producteur_Record == null) {
				
					this.col_Compte_producteur_Record = new Compte_Record(this.connectionString, this.col_Compte_producteur);
				}
				
				return(this.col_Compte_producteur_Record);
			}
		}

		internal bool col_Compte_preleve_plan_conjointWasSet = false;
		private bool col_Compte_preleve_plan_conjointWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_preleve_plan_conjoint = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_preleve_plan_conjoint {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Compte_preleve_plan_conjoint);
			}
			set {
			
				this.col_Compte_preleve_plan_conjointWasUpdated = true;
				this.col_Compte_preleve_plan_conjointWasSet = true;
				this.col_Compte_preleve_plan_conjoint_Record = null;
				this.col_Compte_preleve_plan_conjoint = value;
			}
		}

		
		private Compte_Record col_Compte_preleve_plan_conjoint_Record = null;
		public Compte_Record Col_Compte_preleve_plan_conjoint_Compte_Record {
		
			get {

				if (this.col_Compte_preleve_plan_conjoint_Record == null) {
				
					this.col_Compte_preleve_plan_conjoint_Record = new Compte_Record(this.connectionString, this.col_Compte_preleve_plan_conjoint);
				}
				
				return(this.col_Compte_preleve_plan_conjoint_Record);
			}
		}

		internal bool col_Compte_preleve_fond_roulementWasSet = false;
		private bool col_Compte_preleve_fond_roulementWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_preleve_fond_roulement = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_preleve_fond_roulement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Compte_preleve_fond_roulement);
			}
			set {
			
				this.col_Compte_preleve_fond_roulementWasUpdated = true;
				this.col_Compte_preleve_fond_roulementWasSet = true;
				this.col_Compte_preleve_fond_roulement_Record = null;
				this.col_Compte_preleve_fond_roulement = value;
			}
		}

		
		private Compte_Record col_Compte_preleve_fond_roulement_Record = null;
		public Compte_Record Col_Compte_preleve_fond_roulement_Compte_Record {
		
			get {

				if (this.col_Compte_preleve_fond_roulement_Record == null) {
				
					this.col_Compte_preleve_fond_roulement_Record = new Compte_Record(this.connectionString, this.col_Compte_preleve_fond_roulement);
				}
				
				return(this.col_Compte_preleve_fond_roulement_Record);
			}
		}

		internal bool col_Compte_preleve_fond_forestierWasSet = false;
		private bool col_Compte_preleve_fond_forestierWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_preleve_fond_forestier = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_preleve_fond_forestier {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Compte_preleve_fond_forestier);
			}
			set {
			
				this.col_Compte_preleve_fond_forestierWasUpdated = true;
				this.col_Compte_preleve_fond_forestierWasSet = true;
				this.col_Compte_preleve_fond_forestier_Record = null;
				this.col_Compte_preleve_fond_forestier = value;
			}
		}

		
		private Compte_Record col_Compte_preleve_fond_forestier_Record = null;
		public Compte_Record Col_Compte_preleve_fond_forestier_Compte_Record {
		
			get {

				if (this.col_Compte_preleve_fond_forestier_Record == null) {
				
					this.col_Compte_preleve_fond_forestier_Record = new Compte_Record(this.connectionString, this.col_Compte_preleve_fond_forestier);
				}
				
				return(this.col_Compte_preleve_fond_forestier_Record);
			}
		}

		internal bool col_Compte_preleve_diversWasSet = false;
		private bool col_Compte_preleve_diversWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_preleve_divers = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_preleve_divers {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Compte_preleve_divers);
			}
			set {
			
				this.col_Compte_preleve_diversWasUpdated = true;
				this.col_Compte_preleve_diversWasSet = true;
				this.col_Compte_preleve_divers_Record = null;
				this.col_Compte_preleve_divers = value;
			}
		}

		
		private Compte_Record col_Compte_preleve_divers_Record = null;
		public Compte_Record Col_Compte_preleve_divers_Compte_Record {
		
			get {

				if (this.col_Compte_preleve_divers_Record == null) {
				
					this.col_Compte_preleve_divers_Record = new Compte_Record(this.connectionString, this.col_Compte_preleve_divers);
				}
				
				return(this.col_Compte_preleve_divers_Record);
			}
		}

		internal bool col_Compte_mise_en_communWasSet = false;
		private bool col_Compte_mise_en_communWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_mise_en_commun = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_mise_en_commun {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Compte_mise_en_commun);
			}
			set {
			
				this.col_Compte_mise_en_communWasUpdated = true;
				this.col_Compte_mise_en_communWasSet = true;
				this.col_Compte_mise_en_commun_Record = null;
				this.col_Compte_mise_en_commun = value;
			}
		}

		
		private Compte_Record col_Compte_mise_en_commun_Record = null;
		public Compte_Record Col_Compte_mise_en_commun_Compte_Record {
		
			get {

				if (this.col_Compte_mise_en_commun_Record == null) {
				
					this.col_Compte_mise_en_commun_Record = new Compte_Record(this.connectionString, this.col_Compte_mise_en_commun);
				}
				
				return(this.col_Compte_mise_en_commun_Record);
			}
		}

		internal bool col_Compte_surchargeWasSet = false;
		private bool col_Compte_surchargeWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_surcharge = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_surcharge {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Compte_surcharge);
			}
			set {
			
				this.col_Compte_surchargeWasUpdated = true;
				this.col_Compte_surchargeWasSet = true;
				this.col_Compte_surcharge_Record = null;
				this.col_Compte_surcharge = value;
			}
		}

		
		private Compte_Record col_Compte_surcharge_Record = null;
		public Compte_Record Col_Compte_surcharge_Compte_Record {
		
			get {

				if (this.col_Compte_surcharge_Record == null) {
				
					this.col_Compte_surcharge_Record = new Compte_Record(this.connectionString, this.col_Compte_surcharge);
				}
				
				return(this.col_Compte_surcharge_Record);
			}
		}

		internal bool col_Compte_indexation_carburantWasSet = false;
		private bool col_Compte_indexation_carburantWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_indexation_carburant = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_indexation_carburant {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Compte_indexation_carburant);
			}
			set {
			
				this.col_Compte_indexation_carburantWasUpdated = true;
				this.col_Compte_indexation_carburantWasSet = true;
				this.col_Compte_indexation_carburant_Record = null;
				this.col_Compte_indexation_carburant = value;
			}
		}

		
		private Compte_Record col_Compte_indexation_carburant_Record = null;
		public Compte_Record Col_Compte_indexation_carburant_Compte_Record {
		
			get {

				if (this.col_Compte_indexation_carburant_Record == null) {
				
					this.col_Compte_indexation_carburant_Record = new Compte_Record(this.connectionString, this.col_Compte_indexation_carburant);
				}
				
				return(this.col_Compte_indexation_carburant_Record);
			}
		}

		internal bool col_ActifWasSet = false;
		private bool col_ActifWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Actif = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Actif {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Actif);
			}
			set {
			
				this.col_ActifWasUpdated = true;
				this.col_ActifWasSet = true;
				this.col_Actif = value;
			}
		}

		internal bool col_NePaiePasTPSWasSet = false;
		private bool col_NePaiePasTPSWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_NePaiePasTPS = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_NePaiePasTPS {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NePaiePasTPS);
			}
			set {
			
				this.col_NePaiePasTPSWasUpdated = true;
				this.col_NePaiePasTPSWasSet = true;
				this.col_NePaiePasTPS = value;
			}
		}

		internal bool col_NePaiePasTVQWasSet = false;
		private bool col_NePaiePasTVQWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_NePaiePasTVQ = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_NePaiePasTVQ {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NePaiePasTVQ);
			}
			set {
			
				this.col_NePaiePasTVQWasUpdated = true;
				this.col_NePaiePasTVQWasSet = true;
				this.col_NePaiePasTVQ = value;
			}
		}

		internal bool col_NoTPSWasSet = false;
		private bool col_NoTPSWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_NoTPS = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_NoTPS {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NoTPS);
			}
			set {
			
				this.col_NoTPSWasUpdated = true;
				this.col_NoTPSWasSet = true;
				this.col_NoTPS = value;
			}
		}

		internal bool col_NoTVQWasSet = false;
		private bool col_NoTVQWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_NoTVQ = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_NoTVQ {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_NoTVQ);
			}
			set {
			
				this.col_NoTVQWasUpdated = true;
				this.col_NoTVQWasSet = true;
				this.col_NoTVQ = value;
			}
		}

		internal bool col_Compte_chargeurWasSet = false;
		private bool col_Compte_chargeurWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte_chargeur = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_chargeur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Compte_chargeur);
			}
			set {
			
				this.col_Compte_chargeurWasUpdated = true;
				this.col_Compte_chargeurWasSet = true;
				this.col_Compte_chargeur = value;
			}
		}

		internal bool col_UsineGestionVolumeWasSet = false;
		private bool col_UsineGestionVolumeWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_UsineGestionVolume = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_UsineGestionVolume {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UsineGestionVolume);
			}
			set {
			
				this.col_UsineGestionVolumeWasUpdated = true;
				this.col_UsineGestionVolumeWasSet = true;
				this.col_UsineGestionVolume = value;
			}
		}

		internal bool col_AuSoinsDeWasSet = false;
		private bool col_AuSoinsDeWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_AuSoinsDe = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_AuSoinsDe {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_AuSoinsDe);
			}
			set {
			
				this.col_AuSoinsDeWasUpdated = true;
				this.col_AuSoinsDeWasSet = true;
				this.col_AuSoinsDe = value;
			}
		}

		internal bool col_RueWasSet = false;
		private bool col_RueWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Rue = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Rue {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Rue);
			}
			set {
			
				this.col_RueWasUpdated = true;
				this.col_RueWasSet = true;
				this.col_Rue = value;
			}
		}

		internal bool col_VilleWasSet = false;
		private bool col_VilleWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Ville = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Ville {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Ville);
			}
			set {
			
				this.col_VilleWasUpdated = true;
				this.col_VilleWasSet = true;
				this.col_Ville = value;
			}
		}

		internal bool col_PaysIDWasSet = false;
		private bool col_PaysIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_PaysID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_PaysID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PaysID);
			}
			set {
			
				this.col_PaysIDWasUpdated = true;
				this.col_PaysIDWasSet = true;
				this.col_PaysID_Record = null;
				this.col_PaysID = value;
			}
		}

		
		private Pays_Record col_PaysID_Record = null;
		public Pays_Record Col_PaysID_Pays_Record {
		
			get {

				if (this.col_PaysID_Record == null) {
				
					this.col_PaysID_Record = new Pays_Record(this.connectionString, this.col_PaysID);
				}
				
				return(this.col_PaysID_Record);
			}
		}

		internal bool col_Code_postalWasSet = false;
		private bool col_Code_postalWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Code_postal = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Code_postal {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Code_postal);
			}
			set {
			
				this.col_Code_postalWasUpdated = true;
				this.col_Code_postalWasSet = true;
				this.col_Code_postal = value;
			}
		}

		internal bool col_TelephoneWasSet = false;
		private bool col_TelephoneWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone);
			}
			set {
			
				this.col_TelephoneWasUpdated = true;
				this.col_TelephoneWasSet = true;
				this.col_Telephone = value;
			}
		}

		internal bool col_Telephone_PosteWasSet = false;
		private bool col_Telephone_PosteWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone_Poste {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone_Poste);
			}
			set {
			
				this.col_Telephone_PosteWasUpdated = true;
				this.col_Telephone_PosteWasSet = true;
				this.col_Telephone_Poste = value;
			}
		}

		internal bool col_TelecopieurWasSet = false;
		private bool col_TelecopieurWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telecopieur = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telecopieur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telecopieur);
			}
			set {
			
				this.col_TelecopieurWasUpdated = true;
				this.col_TelecopieurWasSet = true;
				this.col_Telecopieur = value;
			}
		}

		internal bool col_Telephone2WasSet = false;
		private bool col_Telephone2WasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone2 = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone2 {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone2);
			}
			set {
			
				this.col_Telephone2WasUpdated = true;
				this.col_Telephone2WasSet = true;
				this.col_Telephone2 = value;
			}
		}

		internal bool col_Telephone2_DescWasSet = false;
		private bool col_Telephone2_DescWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone2_Desc = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone2_Desc {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone2_Desc);
			}
			set {
			
				this.col_Telephone2_DescWasUpdated = true;
				this.col_Telephone2_DescWasSet = true;
				this.col_Telephone2_Desc = value;
			}
		}

		internal bool col_Telephone2_PosteWasSet = false;
		private bool col_Telephone2_PosteWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone2_Poste = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone2_Poste {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone2_Poste);
			}
			set {
			
				this.col_Telephone2_PosteWasUpdated = true;
				this.col_Telephone2_PosteWasSet = true;
				this.col_Telephone2_Poste = value;
			}
		}

		internal bool col_Telephone3WasSet = false;
		private bool col_Telephone3WasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone3 = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone3 {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone3);
			}
			set {
			
				this.col_Telephone3WasUpdated = true;
				this.col_Telephone3WasSet = true;
				this.col_Telephone3 = value;
			}
		}

		internal bool col_Telephone3_DescWasSet = false;
		private bool col_Telephone3_DescWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone3_Desc = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone3_Desc {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone3_Desc);
			}
			set {
			
				this.col_Telephone3_DescWasUpdated = true;
				this.col_Telephone3_DescWasSet = true;
				this.col_Telephone3_Desc = value;
			}
		}

		internal bool col_Telephone3_PosteWasSet = false;
		private bool col_Telephone3_PosteWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Telephone3_Poste = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Telephone3_Poste {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Telephone3_Poste);
			}
			set {
			
				this.col_Telephone3_PosteWasUpdated = true;
				this.col_Telephone3_PosteWasSet = true;
				this.col_Telephone3_Poste = value;
			}
		}

		internal bool col_EmailWasSet = false;
		private bool col_EmailWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Email = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Email {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Email);
			}
			set {
			
				this.col_EmailWasUpdated = true;
				this.col_EmailWasSet = true;
				this.col_Email = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_DescriptionWasUpdated = false;
			this.col_DescriptionWasSet = false;
			this.col_Description = System.Data.SqlTypes.SqlString.Null;

			this.col_UtilisationIDWasUpdated = false;
			this.col_UtilisationIDWasSet = false;
			this.col_UtilisationID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Paye_producteurWasUpdated = false;
			this.col_Paye_producteurWasSet = false;
			this.col_Paye_producteur = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Paye_transporteurWasUpdated = false;
			this.col_Paye_transporteurWasSet = false;
			this.col_Paye_transporteur = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_SpecificationWasUpdated = false;
			this.col_SpecificationWasSet = false;
			this.col_Specification = System.Data.SqlTypes.SqlString.Null;

			this.col_Compte_a_recevoirWasUpdated = false;
			this.col_Compte_a_recevoirWasSet = false;
			this.col_Compte_a_recevoir = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Compte_ajustementWasUpdated = false;
			this.col_Compte_ajustementWasSet = false;
			this.col_Compte_ajustement = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Compte_transporteurWasUpdated = false;
			this.col_Compte_transporteurWasSet = false;
			this.col_Compte_transporteur = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Compte_producteurWasUpdated = false;
			this.col_Compte_producteurWasSet = false;
			this.col_Compte_producteur = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Compte_preleve_plan_conjointWasUpdated = false;
			this.col_Compte_preleve_plan_conjointWasSet = false;
			this.col_Compte_preleve_plan_conjoint = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Compte_preleve_fond_roulementWasUpdated = false;
			this.col_Compte_preleve_fond_roulementWasSet = false;
			this.col_Compte_preleve_fond_roulement = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Compte_preleve_fond_forestierWasUpdated = false;
			this.col_Compte_preleve_fond_forestierWasSet = false;
			this.col_Compte_preleve_fond_forestier = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Compte_preleve_diversWasUpdated = false;
			this.col_Compte_preleve_diversWasSet = false;
			this.col_Compte_preleve_divers = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Compte_mise_en_communWasUpdated = false;
			this.col_Compte_mise_en_communWasSet = false;
			this.col_Compte_mise_en_commun = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Compte_surchargeWasUpdated = false;
			this.col_Compte_surchargeWasSet = false;
			this.col_Compte_surcharge = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Compte_indexation_carburantWasUpdated = false;
			this.col_Compte_indexation_carburantWasSet = false;
			this.col_Compte_indexation_carburant = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_NePaiePasTPSWasUpdated = false;
			this.col_NePaiePasTPSWasSet = false;
			this.col_NePaiePasTPS = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_NePaiePasTVQWasUpdated = false;
			this.col_NePaiePasTVQWasSet = false;
			this.col_NePaiePasTVQ = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_NoTPSWasUpdated = false;
			this.col_NoTPSWasSet = false;
			this.col_NoTPS = System.Data.SqlTypes.SqlString.Null;

			this.col_NoTVQWasUpdated = false;
			this.col_NoTVQWasSet = false;
			this.col_NoTVQ = System.Data.SqlTypes.SqlString.Null;

			this.col_Compte_chargeurWasUpdated = false;
			this.col_Compte_chargeurWasSet = false;
			this.col_Compte_chargeur = System.Data.SqlTypes.SqlInt32.Null;

			this.col_UsineGestionVolumeWasUpdated = false;
			this.col_UsineGestionVolumeWasSet = false;
			this.col_UsineGestionVolume = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_AuSoinsDeWasUpdated = false;
			this.col_AuSoinsDeWasSet = false;
			this.col_AuSoinsDe = System.Data.SqlTypes.SqlString.Null;

			this.col_RueWasUpdated = false;
			this.col_RueWasSet = false;
			this.col_Rue = System.Data.SqlTypes.SqlString.Null;

			this.col_VilleWasUpdated = false;
			this.col_VilleWasSet = false;
			this.col_Ville = System.Data.SqlTypes.SqlString.Null;

			this.col_PaysIDWasUpdated = false;
			this.col_PaysIDWasSet = false;
			this.col_PaysID = System.Data.SqlTypes.SqlString.Null;

			this.col_Code_postalWasUpdated = false;
			this.col_Code_postalWasSet = false;
			this.col_Code_postal = System.Data.SqlTypes.SqlString.Null;

			this.col_TelephoneWasUpdated = false;
			this.col_TelephoneWasSet = false;
			this.col_Telephone = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone_PosteWasUpdated = false;
			this.col_Telephone_PosteWasSet = false;
			this.col_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;

			this.col_TelecopieurWasUpdated = false;
			this.col_TelecopieurWasSet = false;
			this.col_Telecopieur = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone2WasUpdated = false;
			this.col_Telephone2WasSet = false;
			this.col_Telephone2 = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone2_DescWasUpdated = false;
			this.col_Telephone2_DescWasSet = false;
			this.col_Telephone2_Desc = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone2_PosteWasUpdated = false;
			this.col_Telephone2_PosteWasSet = false;
			this.col_Telephone2_Poste = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone3WasUpdated = false;
			this.col_Telephone3WasSet = false;
			this.col_Telephone3 = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone3_DescWasUpdated = false;
			this.col_Telephone3_DescWasSet = false;
			this.col_Telephone3_Desc = System.Data.SqlTypes.SqlString.Null;

			this.col_Telephone3_PosteWasUpdated = false;
			this.col_Telephone3_PosteWasSet = false;
			this.col_Telephone3_Poste = System.Data.SqlTypes.SqlString.Null;

			this.col_EmailWasUpdated = false;
			this.col_EmailWasSet = false;
			this.col_Email = System.Data.SqlTypes.SqlString.Null;

			Params.spS_Usine Param = new Params.spS_Usine(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Usine Sp = new SPs.spS_Usine();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Description.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_UtilisationID.ColumnIndex)) {

						this.col_UtilisationID = sqlDataReader.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_UtilisationID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Paye_producteur.ColumnIndex)) {

						this.col_Paye_producteur = sqlDataReader.GetSqlBoolean(SPs.spS_Usine.Resultset1.Fields.Column_Paye_producteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Paye_transporteur.ColumnIndex)) {

						this.col_Paye_transporteur = sqlDataReader.GetSqlBoolean(SPs.spS_Usine.Resultset1.Fields.Column_Paye_transporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Specification.ColumnIndex)) {

						this.col_Specification = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Specification.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_a_recevoir.ColumnIndex)) {

						this.col_Compte_a_recevoir = sqlDataReader.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_a_recevoir.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_ajustement.ColumnIndex)) {

						this.col_Compte_ajustement = sqlDataReader.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_ajustement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_transporteur.ColumnIndex)) {

						this.col_Compte_transporteur = sqlDataReader.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_transporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_producteur.ColumnIndex)) {

						this.col_Compte_producteur = sqlDataReader.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_producteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_plan_conjoint.ColumnIndex)) {

						this.col_Compte_preleve_plan_conjoint = sqlDataReader.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_plan_conjoint.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_fond_roulement.ColumnIndex)) {

						this.col_Compte_preleve_fond_roulement = sqlDataReader.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_fond_roulement.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_fond_forestier.ColumnIndex)) {

						this.col_Compte_preleve_fond_forestier = sqlDataReader.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_fond_forestier.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_divers.ColumnIndex)) {

						this.col_Compte_preleve_divers = sqlDataReader.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_preleve_divers.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_mise_en_commun.ColumnIndex)) {

						this.col_Compte_mise_en_commun = sqlDataReader.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_mise_en_commun.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_surcharge.ColumnIndex)) {

						this.col_Compte_surcharge = sqlDataReader.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_surcharge.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_indexation_carburant.ColumnIndex)) {

						this.col_Compte_indexation_carburant = sqlDataReader.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_indexation_carburant.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Usine.Resultset1.Fields.Column_Actif.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_NePaiePasTPS.ColumnIndex)) {

						this.col_NePaiePasTPS = sqlDataReader.GetSqlBoolean(SPs.spS_Usine.Resultset1.Fields.Column_NePaiePasTPS.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_NePaiePasTVQ.ColumnIndex)) {

						this.col_NePaiePasTVQ = sqlDataReader.GetSqlBoolean(SPs.spS_Usine.Resultset1.Fields.Column_NePaiePasTVQ.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_NoTPS.ColumnIndex)) {

						this.col_NoTPS = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_NoTPS.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_NoTVQ.ColumnIndex)) {

						this.col_NoTVQ = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_NoTVQ.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Compte_chargeur.ColumnIndex)) {

						this.col_Compte_chargeur = sqlDataReader.GetSqlInt32(SPs.spS_Usine.Resultset1.Fields.Column_Compte_chargeur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_UsineGestionVolume.ColumnIndex)) {

						this.col_UsineGestionVolume = sqlDataReader.GetSqlBoolean(SPs.spS_Usine.Resultset1.Fields.Column_UsineGestionVolume.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_AuSoinsDe.ColumnIndex)) {

						this.col_AuSoinsDe = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_AuSoinsDe.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Rue.ColumnIndex)) {

						this.col_Rue = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Rue.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Ville.ColumnIndex)) {

						this.col_Ville = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Ville.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_PaysID.ColumnIndex)) {

						this.col_PaysID = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_PaysID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Code_postal.ColumnIndex)) {

						this.col_Code_postal = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Code_postal.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone.ColumnIndex)) {

						this.col_Telephone = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone_Poste.ColumnIndex)) {

						this.col_Telephone_Poste = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone_Poste.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telecopieur.ColumnIndex)) {

						this.col_Telecopieur = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telecopieur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone2.ColumnIndex)) {

						this.col_Telephone2 = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone2.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone2_Desc.ColumnIndex)) {

						this.col_Telephone2_Desc = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone2_Desc.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone2_Poste.ColumnIndex)) {

						this.col_Telephone2_Poste = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone2_Poste.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone3.ColumnIndex)) {

						this.col_Telephone3 = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone3.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone3_Desc.ColumnIndex)) {

						this.col_Telephone3_Desc = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone3_Desc.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Telephone3_Poste.ColumnIndex)) {

						this.col_Telephone3_Poste = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Telephone3_Poste.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Usine.Resultset1.Fields.Column_Email.ColumnIndex)) {

						this.col_Email = sqlDataReader.GetSqlString(SPs.spS_Usine.Resultset1.Fields.Column_Email.ColumnIndex);
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = true;

					return(true);
				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = false;

					return(false);
				}
			}
			else {

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Usine_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UtilisationIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Paye_producteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Paye_transporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_SpecificationWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Compte_a_recevoirWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Compte_ajustementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Compte_transporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Compte_producteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Compte_preleve_plan_conjointWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Compte_preleve_fond_roulementWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Compte_preleve_fond_forestierWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Compte_preleve_diversWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Compte_mise_en_communWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Compte_surchargeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Compte_indexation_carburantWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NePaiePasTPSWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NePaiePasTVQWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NoTPSWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_NoTVQWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Compte_chargeurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UsineGestionVolumeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AuSoinsDeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_RueWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VilleWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PaysIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Code_postalWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TelephoneWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone_PosteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TelecopieurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone2WasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone2_DescWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone2_PosteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone3WasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone3_DescWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Telephone3_PosteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EmailWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Usine Param = new Params.spU_Usine(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_DescriptionWasUpdated) {

				Param.Param_Description = this.col_Description;
				Param.Param_ConsiderNull_Description = true;
			}

			if (this.col_UtilisationIDWasUpdated) {

				Param.Param_UtilisationID = this.col_UtilisationID;
				Param.Param_ConsiderNull_UtilisationID = true;
			}

			if (this.col_Paye_producteurWasUpdated) {

				Param.Param_Paye_producteur = this.col_Paye_producteur;
				Param.Param_ConsiderNull_Paye_producteur = true;
			}

			if (this.col_Paye_transporteurWasUpdated) {

				Param.Param_Paye_transporteur = this.col_Paye_transporteur;
				Param.Param_ConsiderNull_Paye_transporteur = true;
			}

			if (this.col_SpecificationWasUpdated) {

				Param.Param_Specification = this.col_Specification;
				Param.Param_ConsiderNull_Specification = true;
			}

			if (this.col_Compte_a_recevoirWasUpdated) {

				Param.Param_Compte_a_recevoir = this.col_Compte_a_recevoir;
				Param.Param_ConsiderNull_Compte_a_recevoir = true;
			}

			if (this.col_Compte_ajustementWasUpdated) {

				Param.Param_Compte_ajustement = this.col_Compte_ajustement;
				Param.Param_ConsiderNull_Compte_ajustement = true;
			}

			if (this.col_Compte_transporteurWasUpdated) {

				Param.Param_Compte_transporteur = this.col_Compte_transporteur;
				Param.Param_ConsiderNull_Compte_transporteur = true;
			}

			if (this.col_Compte_producteurWasUpdated) {

				Param.Param_Compte_producteur = this.col_Compte_producteur;
				Param.Param_ConsiderNull_Compte_producteur = true;
			}

			if (this.col_Compte_preleve_plan_conjointWasUpdated) {

				Param.Param_Compte_preleve_plan_conjoint = this.col_Compte_preleve_plan_conjoint;
				Param.Param_ConsiderNull_Compte_preleve_plan_conjoint = true;
			}

			if (this.col_Compte_preleve_fond_roulementWasUpdated) {

				Param.Param_Compte_preleve_fond_roulement = this.col_Compte_preleve_fond_roulement;
				Param.Param_ConsiderNull_Compte_preleve_fond_roulement = true;
			}

			if (this.col_Compte_preleve_fond_forestierWasUpdated) {

				Param.Param_Compte_preleve_fond_forestier = this.col_Compte_preleve_fond_forestier;
				Param.Param_ConsiderNull_Compte_preleve_fond_forestier = true;
			}

			if (this.col_Compte_preleve_diversWasUpdated) {

				Param.Param_Compte_preleve_divers = this.col_Compte_preleve_divers;
				Param.Param_ConsiderNull_Compte_preleve_divers = true;
			}

			if (this.col_Compte_mise_en_communWasUpdated) {

				Param.Param_Compte_mise_en_commun = this.col_Compte_mise_en_commun;
				Param.Param_ConsiderNull_Compte_mise_en_commun = true;
			}

			if (this.col_Compte_surchargeWasUpdated) {

				Param.Param_Compte_surcharge = this.col_Compte_surcharge;
				Param.Param_ConsiderNull_Compte_surcharge = true;
			}

			if (this.col_Compte_indexation_carburantWasUpdated) {

				Param.Param_Compte_indexation_carburant = this.col_Compte_indexation_carburant;
				Param.Param_ConsiderNull_Compte_indexation_carburant = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			if (this.col_NePaiePasTPSWasUpdated) {

				Param.Param_NePaiePasTPS = this.col_NePaiePasTPS;
				Param.Param_ConsiderNull_NePaiePasTPS = true;
			}

			if (this.col_NePaiePasTVQWasUpdated) {

				Param.Param_NePaiePasTVQ = this.col_NePaiePasTVQ;
				Param.Param_ConsiderNull_NePaiePasTVQ = true;
			}

			if (this.col_NoTPSWasUpdated) {

				Param.Param_NoTPS = this.col_NoTPS;
				Param.Param_ConsiderNull_NoTPS = true;
			}

			if (this.col_NoTVQWasUpdated) {

				Param.Param_NoTVQ = this.col_NoTVQ;
				Param.Param_ConsiderNull_NoTVQ = true;
			}

			if (this.col_Compte_chargeurWasUpdated) {

				Param.Param_Compte_chargeur = this.col_Compte_chargeur;
				Param.Param_ConsiderNull_Compte_chargeur = true;
			}

			if (this.col_UsineGestionVolumeWasUpdated) {

				Param.Param_UsineGestionVolume = this.col_UsineGestionVolume;
				Param.Param_ConsiderNull_UsineGestionVolume = true;
			}

			if (this.col_AuSoinsDeWasUpdated) {

				Param.Param_AuSoinsDe = this.col_AuSoinsDe;
				Param.Param_ConsiderNull_AuSoinsDe = true;
			}

			if (this.col_RueWasUpdated) {

				Param.Param_Rue = this.col_Rue;
				Param.Param_ConsiderNull_Rue = true;
			}

			if (this.col_VilleWasUpdated) {

				Param.Param_Ville = this.col_Ville;
				Param.Param_ConsiderNull_Ville = true;
			}

			if (this.col_PaysIDWasUpdated) {

				Param.Param_PaysID = this.col_PaysID;
				Param.Param_ConsiderNull_PaysID = true;
			}

			if (this.col_Code_postalWasUpdated) {

				Param.Param_Code_postal = this.col_Code_postal;
				Param.Param_ConsiderNull_Code_postal = true;
			}

			if (this.col_TelephoneWasUpdated) {

				Param.Param_Telephone = this.col_Telephone;
				Param.Param_ConsiderNull_Telephone = true;
			}

			if (this.col_Telephone_PosteWasUpdated) {

				Param.Param_Telephone_Poste = this.col_Telephone_Poste;
				Param.Param_ConsiderNull_Telephone_Poste = true;
			}

			if (this.col_TelecopieurWasUpdated) {

				Param.Param_Telecopieur = this.col_Telecopieur;
				Param.Param_ConsiderNull_Telecopieur = true;
			}

			if (this.col_Telephone2WasUpdated) {

				Param.Param_Telephone2 = this.col_Telephone2;
				Param.Param_ConsiderNull_Telephone2 = true;
			}

			if (this.col_Telephone2_DescWasUpdated) {

				Param.Param_Telephone2_Desc = this.col_Telephone2_Desc;
				Param.Param_ConsiderNull_Telephone2_Desc = true;
			}

			if (this.col_Telephone2_PosteWasUpdated) {

				Param.Param_Telephone2_Poste = this.col_Telephone2_Poste;
				Param.Param_ConsiderNull_Telephone2_Poste = true;
			}

			if (this.col_Telephone3WasUpdated) {

				Param.Param_Telephone3 = this.col_Telephone3;
				Param.Param_ConsiderNull_Telephone3 = true;
			}

			if (this.col_Telephone3_DescWasUpdated) {

				Param.Param_Telephone3_Desc = this.col_Telephone3_Desc;
				Param.Param_ConsiderNull_Telephone3_Desc = true;
			}

			if (this.col_Telephone3_PosteWasUpdated) {

				Param.Param_Telephone3_Poste = this.col_Telephone3_Poste;
				Param.Param_ConsiderNull_Telephone3_Poste = true;
			}

			if (this.col_EmailWasUpdated) {

				Param.Param_Email = this.col_Email;
				Param.Param_ConsiderNull_Email = true;
			}

			SPs.spU_Usine Sp = new SPs.spU_Usine();
			if (Sp.Execute(ref Param)) {

				this.col_DescriptionWasUpdated = false;
				this.col_UtilisationIDWasUpdated = false;
				this.col_Paye_producteurWasUpdated = false;
				this.col_Paye_transporteurWasUpdated = false;
				this.col_SpecificationWasUpdated = false;
				this.col_Compte_a_recevoirWasUpdated = false;
				this.col_Compte_ajustementWasUpdated = false;
				this.col_Compte_transporteurWasUpdated = false;
				this.col_Compte_producteurWasUpdated = false;
				this.col_Compte_preleve_plan_conjointWasUpdated = false;
				this.col_Compte_preleve_fond_roulementWasUpdated = false;
				this.col_Compte_preleve_fond_forestierWasUpdated = false;
				this.col_Compte_preleve_diversWasUpdated = false;
				this.col_Compte_mise_en_communWasUpdated = false;
				this.col_Compte_surchargeWasUpdated = false;
				this.col_Compte_indexation_carburantWasUpdated = false;
				this.col_ActifWasUpdated = false;
				this.col_NePaiePasTPSWasUpdated = false;
				this.col_NePaiePasTVQWasUpdated = false;
				this.col_NoTPSWasUpdated = false;
				this.col_NoTVQWasUpdated = false;
				this.col_Compte_chargeurWasUpdated = false;
				this.col_UsineGestionVolumeWasUpdated = false;
				this.col_AuSoinsDeWasUpdated = false;
				this.col_RueWasUpdated = false;
				this.col_VilleWasUpdated = false;
				this.col_PaysIDWasUpdated = false;
				this.col_Code_postalWasUpdated = false;
				this.col_TelephoneWasUpdated = false;
				this.col_Telephone_PosteWasUpdated = false;
				this.col_TelecopieurWasUpdated = false;
				this.col_Telephone2WasUpdated = false;
				this.col_Telephone2_DescWasUpdated = false;
				this.col_Telephone2_PosteWasUpdated = false;
				this.col_Telephone3WasUpdated = false;
				this.col_Telephone3_DescWasUpdated = false;
				this.col_Telephone3_PosteWasUpdated = false;
				this.col_EmailWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Usine_Record", "Update");
			}		
		}

		private AjustementCalcule_Usine_Collection internal_AjustementCalcule_Usine_Col_UsineID_Collection = null;
		public AjustementCalcule_Usine_Collection AjustementCalcule_Usine_Col_UsineID_Collection {

			get {

				if (this.internal_AjustementCalcule_Usine_Col_UsineID_Collection == null) {

					this.internal_AjustementCalcule_Usine_Col_UsineID_Collection = new AjustementCalcule_Usine_Collection(this.connectionString);
					this.internal_AjustementCalcule_Usine_Col_UsineID_Collection.LoadFrom_UsineID(this.col_ID, this);
				}

				return(this.internal_AjustementCalcule_Usine_Col_UsineID_Collection);
			}
		}

		private Contingentement_Collection internal_Contingentement_Col_UsineID_Collection = null;
		public Contingentement_Collection Contingentement_Col_UsineID_Collection {

			get {

				if (this.internal_Contingentement_Col_UsineID_Collection == null) {

					this.internal_Contingentement_Col_UsineID_Collection = new Contingentement_Collection(this.connectionString);
					this.internal_Contingentement_Col_UsineID_Collection.LoadFrom_UsineID(this.col_ID, this);
				}

				return(this.internal_Contingentement_Col_UsineID_Collection);
			}
		}

		private Contrat_Collection internal_Contrat_Col_UsineID_Collection = null;
		public Contrat_Collection Contrat_Col_UsineID_Collection {

			get {

				if (this.internal_Contrat_Col_UsineID_Collection == null) {

					this.internal_Contrat_Col_UsineID_Collection = new Contrat_Collection(this.connectionString);
					this.internal_Contrat_Col_UsineID_Collection.LoadFrom_UsineID(this.col_ID, this);
				}

				return(this.internal_Contrat_Col_UsineID_Collection);
			}
		}

		private FactureClient_Collection internal_FactureClient_Col_ClientID_Collection = null;
		public FactureClient_Collection FactureClient_Col_ClientID_Collection {

			get {

				if (this.internal_FactureClient_Col_ClientID_Collection == null) {

					this.internal_FactureClient_Col_ClientID_Collection = new FactureClient_Collection(this.connectionString);
					this.internal_FactureClient_Col_ClientID_Collection.LoadFrom_ClientID(this.col_ID, this);
				}

				return(this.internal_FactureClient_Col_ClientID_Collection);
			}
		}

		private FactureClient_Collection internal_FactureClient_Col_PayerAID_Collection = null;
		public FactureClient_Collection FactureClient_Col_PayerAID_Collection {

			get {

				if (this.internal_FactureClient_Col_PayerAID_Collection == null) {

					this.internal_FactureClient_Col_PayerAID_Collection = new FactureClient_Collection(this.connectionString);
					this.internal_FactureClient_Col_PayerAID_Collection.LoadFrom_PayerAID(this.col_ID, this);
				}

				return(this.internal_FactureClient_Col_PayerAID_Collection);
			}
		}

		private GestionVolume_Collection internal_GestionVolume_Col_UsineID_Collection = null;
		public GestionVolume_Collection GestionVolume_Col_UsineID_Collection {

			get {

				if (this.internal_GestionVolume_Col_UsineID_Collection == null) {

					this.internal_GestionVolume_Col_UsineID_Collection = new GestionVolume_Collection(this.connectionString);
					this.internal_GestionVolume_Col_UsineID_Collection.LoadFrom_UsineID(this.col_ID, this);
				}

				return(this.internal_GestionVolume_Col_UsineID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Usine_Display Param = new Params.spS_Usine_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Usine_Display Sp = new SPs.spS_Usine_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Usine_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Usine_Display";
						}
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Usine_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}

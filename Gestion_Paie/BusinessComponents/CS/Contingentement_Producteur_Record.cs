using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Contingentement_Producteur] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Contingentement_Producteur_Collection"/> class to do so.
	/// </summary>
	public sealed class Contingentement_Producteur_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Contingentement_Producteur_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Contingentement_Producteur_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Contingentement_Producteur_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ContingentementID">[To be supplied.]</param>
		/// <param name="col_ProducteurID">[To be supplied.]</param>
		public Contingentement_Producteur_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ContingentementID, System.Data.SqlTypes.SqlString col_ProducteurID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contingentement_Producteur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contingentement_Producteur", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ContingentementID = col_ContingentementID;
			this.col_ProducteurID = col_ProducteurID;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ContingentementID {
		
			get {
			
				return(this.col_ContingentementID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ContingentementID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlString col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurID {
		
			get {
			
				return(this.col_ProducteurID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ProducteurID = value;
				}
			}
		}
		
		
		private Contingentement_Record col_ContingentementID_Record = null;
		public Contingentement_Record Col_ContingentementID_Contingentement_Record {
		
			get {

				if (this.col_ContingentementID_Record == null) {
				
					this.col_ContingentementID_Record = new Contingentement_Record(this.connectionString, this.col_ContingentementID);
				}
				
				return(this.col_ContingentementID_Record);
			}
		}

		
		private Fournisseur_Record col_ProducteurID_Record = null;
		public Fournisseur_Record Col_ProducteurID_Fournisseur_Record {
		
			get {

				if (this.col_ProducteurID_Record == null) {
				
					this.col_ProducteurID_Record = new Fournisseur_Record(this.connectionString, this.col_ProducteurID);
				}
				
				return(this.col_ProducteurID_Record);
			}
		}

		internal bool col_Superficie_ContingenteeWasSet = false;
		private bool col_Superficie_ContingenteeWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Superficie_Contingentee = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Superficie_Contingentee {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Superficie_Contingentee);
			}
			set {
			
				this.col_Superficie_ContingenteeWasUpdated = true;
				this.col_Superficie_ContingenteeWasSet = true;
				this.col_Superficie_Contingentee = value;
			}
		}

		internal bool col_Volume_DemandeWasSet = false;
		private bool col_Volume_DemandeWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Volume_Demande = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Volume_Demande {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume_Demande);
			}
			set {
			
				this.col_Volume_DemandeWasUpdated = true;
				this.col_Volume_DemandeWasSet = true;
				this.col_Volume_Demande = value;
			}
		}

		internal bool col_Volume_FacteurWasSet = false;
		private bool col_Volume_FacteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Volume_Facteur = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Volume_Facteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume_Facteur);
			}
			set {
			
				this.col_Volume_FacteurWasUpdated = true;
				this.col_Volume_FacteurWasSet = true;
				this.col_Volume_Facteur = value;
			}
		}

		internal bool col_Volume_FixeWasSet = false;
		private bool col_Volume_FixeWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Volume_Fixe = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Volume_Fixe {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume_Fixe);
			}
			set {
			
				this.col_Volume_FixeWasUpdated = true;
				this.col_Volume_FixeWasSet = true;
				this.col_Volume_Fixe = value;
			}
		}

		internal bool col_Volume_SupplementaireWasSet = false;
		private bool col_Volume_SupplementaireWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Volume_Supplementaire = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Volume_Supplementaire {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume_Supplementaire);
			}
			set {
			
				this.col_Volume_SupplementaireWasUpdated = true;
				this.col_Volume_SupplementaireWasSet = true;
				this.col_Volume_Supplementaire = value;
			}
		}

		internal bool col_Volume_AccordeWasSet = false;
		private bool col_Volume_AccordeWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Volume_Accorde = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Volume_Accorde {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume_Accorde);
			}
			set {
			
				this.col_Volume_AccordeWasUpdated = true;
				this.col_Volume_AccordeWasSet = true;
				this.col_Volume_Accorde = value;
			}
		}

		internal bool col_Date_ModificationWasSet = false;
		private bool col_Date_ModificationWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_Date_Modification = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_Date_Modification {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Date_Modification);
			}
			set {
			
				this.col_Date_ModificationWasUpdated = true;
				this.col_Date_ModificationWasSet = true;
				this.col_Date_Modification = value;
			}
		}

		internal bool col_Volume_InventaireWasSet = false;
		private bool col_Volume_InventaireWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_Volume_Inventaire = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_Volume_Inventaire {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume_Inventaire);
			}
			set {
			
				this.col_Volume_InventaireWasUpdated = true;
				this.col_Volume_InventaireWasSet = true;
				this.col_Volume_Inventaire = value;
			}
		}

		internal bool col_LastLivraisonWasSet = false;
		private bool col_LastLivraisonWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_LastLivraison = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_LastLivraison {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_LastLivraison);
			}
			set {
			
				this.col_LastLivraisonWasUpdated = true;
				this.col_LastLivraisonWasSet = true;
				this.col_LastLivraison = value;
			}
		}

		internal bool col_VolumeMaximumWasSet = false;
		private bool col_VolumeMaximumWasUpdated = false;
		internal System.Data.SqlTypes.SqlSingle col_VolumeMaximum = System.Data.SqlTypes.SqlSingle.Null;
		public System.Data.SqlTypes.SqlSingle Col_VolumeMaximum {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_VolumeMaximum);
			}
			set {
			
				this.col_VolumeMaximumWasUpdated = true;
				this.col_VolumeMaximumWasSet = true;
				this.col_VolumeMaximum = value;
			}
		}

		internal bool col_ImprimeWasSet = false;
		private bool col_ImprimeWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Imprime = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Imprime {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Imprime);
			}
			set {
			
				this.col_ImprimeWasUpdated = true;
				this.col_ImprimeWasSet = true;
				this.col_Imprime = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;


			this.col_Superficie_ContingenteeWasUpdated = false;
			this.col_Superficie_ContingenteeWasSet = false;
			this.col_Superficie_Contingentee = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Volume_DemandeWasUpdated = false;
			this.col_Volume_DemandeWasSet = false;
			this.col_Volume_Demande = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Volume_FacteurWasUpdated = false;
			this.col_Volume_FacteurWasSet = false;
			this.col_Volume_Facteur = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Volume_FixeWasUpdated = false;
			this.col_Volume_FixeWasSet = false;
			this.col_Volume_Fixe = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Volume_SupplementaireWasUpdated = false;
			this.col_Volume_SupplementaireWasSet = false;
			this.col_Volume_Supplementaire = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Volume_AccordeWasUpdated = false;
			this.col_Volume_AccordeWasSet = false;
			this.col_Volume_Accorde = System.Data.SqlTypes.SqlSingle.Null;

			this.col_Date_ModificationWasUpdated = false;
			this.col_Date_ModificationWasSet = false;
			this.col_Date_Modification = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_Volume_InventaireWasUpdated = false;
			this.col_Volume_InventaireWasSet = false;
			this.col_Volume_Inventaire = System.Data.SqlTypes.SqlSingle.Null;

			this.col_LastLivraisonWasUpdated = false;
			this.col_LastLivraisonWasSet = false;
			this.col_LastLivraison = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_VolumeMaximumWasUpdated = false;
			this.col_VolumeMaximumWasSet = false;
			this.col_VolumeMaximum = System.Data.SqlTypes.SqlSingle.Null;

			this.col_ImprimeWasUpdated = false;
			this.col_ImprimeWasSet = false;
			this.col_Imprime = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Contingentement_Producteur Param = new Params.spS_Contingentement_Producteur(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ContingentementID.IsNull) {

				Param.Param_ContingentementID = this.col_ContingentementID;
			}

			if (!this.col_ProducteurID.IsNull) {

				Param.Param_ProducteurID = this.col_ProducteurID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Contingentement_Producteur Sp = new SPs.spS_Contingentement_Producteur();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Superficie_Contingentee.ColumnIndex)) {

						this.col_Superficie_Contingentee = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Superficie_Contingentee.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Demande.ColumnIndex)) {

						this.col_Volume_Demande = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Demande.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Facteur.ColumnIndex)) {

						this.col_Volume_Facteur = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Facteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Fixe.ColumnIndex)) {

						this.col_Volume_Fixe = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Fixe.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Supplementaire.ColumnIndex)) {

						this.col_Volume_Supplementaire = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Supplementaire.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Accorde.ColumnIndex)) {

						this.col_Volume_Accorde = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Accorde.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Date_Modification.ColumnIndex)) {

						this.col_Date_Modification = sqlDataReader.GetSqlDateTime(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Date_Modification.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Inventaire.ColumnIndex)) {

						this.col_Volume_Inventaire = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Volume_Inventaire.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_LastLivraison.ColumnIndex)) {

						this.col_LastLivraison = sqlDataReader.GetSqlDateTime(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_LastLivraison.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_VolumeMaximum.ColumnIndex)) {

						this.col_VolumeMaximum = sqlDataReader.GetSqlSingle(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_VolumeMaximum.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Imprime.ColumnIndex)) {

						this.col_Imprime = sqlDataReader.GetSqlBoolean(SPs.spS_Contingentement_Producteur.Resultset1.Fields.Column_Imprime.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Producteur_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Superficie_ContingenteeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Volume_DemandeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Volume_FacteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Volume_FixeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Volume_SupplementaireWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Volume_AccordeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Date_ModificationWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Volume_InventaireWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LastLivraisonWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeMaximumWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ImprimeWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Contingentement_Producteur Param = new Params.spU_Contingentement_Producteur(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ContingentementID = this.col_ContingentementID;
			Param.Param_ProducteurID = this.col_ProducteurID;

			if (this.col_Superficie_ContingenteeWasUpdated) {

				Param.Param_Superficie_Contingentee = this.col_Superficie_Contingentee;
				Param.Param_ConsiderNull_Superficie_Contingentee = true;
			}

			if (this.col_Volume_DemandeWasUpdated) {

				Param.Param_Volume_Demande = this.col_Volume_Demande;
				Param.Param_ConsiderNull_Volume_Demande = true;
			}

			if (this.col_Volume_FacteurWasUpdated) {

				Param.Param_Volume_Facteur = this.col_Volume_Facteur;
				Param.Param_ConsiderNull_Volume_Facteur = true;
			}

			if (this.col_Volume_FixeWasUpdated) {

				Param.Param_Volume_Fixe = this.col_Volume_Fixe;
				Param.Param_ConsiderNull_Volume_Fixe = true;
			}

			if (this.col_Volume_SupplementaireWasUpdated) {

				Param.Param_Volume_Supplementaire = this.col_Volume_Supplementaire;
				Param.Param_ConsiderNull_Volume_Supplementaire = true;
			}

			if (this.col_Volume_AccordeWasUpdated) {

				Param.Param_Volume_Accorde = this.col_Volume_Accorde;
				Param.Param_ConsiderNull_Volume_Accorde = true;
			}

			if (this.col_Date_ModificationWasUpdated) {

				Param.Param_Date_Modification = this.col_Date_Modification;
				Param.Param_ConsiderNull_Date_Modification = true;
			}

			if (this.col_Volume_InventaireWasUpdated) {

				Param.Param_Volume_Inventaire = this.col_Volume_Inventaire;
				Param.Param_ConsiderNull_Volume_Inventaire = true;
			}

			if (this.col_LastLivraisonWasUpdated) {

				Param.Param_LastLivraison = this.col_LastLivraison;
				Param.Param_ConsiderNull_LastLivraison = true;
			}

			if (this.col_VolumeMaximumWasUpdated) {

				Param.Param_VolumeMaximum = this.col_VolumeMaximum;
				Param.Param_ConsiderNull_VolumeMaximum = true;
			}

			if (this.col_ImprimeWasUpdated) {

				Param.Param_Imprime = this.col_Imprime;
				Param.Param_ConsiderNull_Imprime = true;
			}

			SPs.spU_Contingentement_Producteur Sp = new SPs.spU_Contingentement_Producteur();
			if (Sp.Execute(ref Param)) {

				this.col_Superficie_ContingenteeWasUpdated = false;
				this.col_Volume_DemandeWasUpdated = false;
				this.col_Volume_FacteurWasUpdated = false;
				this.col_Volume_FixeWasUpdated = false;
				this.col_Volume_SupplementaireWasUpdated = false;
				this.col_Volume_AccordeWasUpdated = false;
				this.col_Date_ModificationWasUpdated = false;
				this.col_Volume_InventaireWasUpdated = false;
				this.col_LastLivraisonWasUpdated = false;
				this.col_VolumeMaximumWasUpdated = false;
				this.col_ImprimeWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Producteur_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Contingentement_Producteur_Display Param = new Params.spS_Contingentement_Producteur_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ContingentementID = this.col_ContingentementID;
				Param.Param_ProducteurID = this.col_ProducteurID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Contingentement_Producteur_Display Sp = new SPs.spS_Contingentement_Producteur_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Contingentement_Producteur_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Contingentement_Producteur_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contingentement_Producteur_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}

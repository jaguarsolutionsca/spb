using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Contrat] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Contrat_Collection"/> class to do so.
	/// </summary>
	public sealed class Contrat_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Contrat_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Contrat_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Contrat_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public Contrat_Record(string connectionString, System.Data.SqlTypes.SqlString col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Contrat'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Contrat", CurrentRevision, OriginalRevision));
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

		internal bool col_UsineIDWasSet = false;
		private bool col_UsineIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_UsineID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UsineID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UsineID);
			}
			set {
			
				this.col_UsineIDWasUpdated = true;
				this.col_UsineIDWasSet = true;
				this.col_UsineID_Record = null;
				this.col_UsineID = value;
			}
		}

		
		private Usine_Record col_UsineID_Record = null;
		public Usine_Record Col_UsineID_Usine_Record {
		
			get {

				if (this.col_UsineID_Record == null) {
				
					this.col_UsineID_Record = new Usine_Record(this.connectionString, this.col_UsineID);
				}
				
				return(this.col_UsineID_Record);
			}
		}

		internal bool col_AnneeWasSet = false;
		private bool col_AnneeWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Annee = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Annee {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Annee);
			}
			set {
			
				this.col_AnneeWasUpdated = true;
				this.col_AnneeWasSet = true;
				this.col_Annee = value;
			}
		}

		internal bool col_Date_debutWasSet = false;
		private bool col_Date_debutWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_Date_debut = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_Date_debut {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Date_debut);
			}
			set {
			
				this.col_Date_debutWasUpdated = true;
				this.col_Date_debutWasSet = true;
				this.col_Date_debut = value;
			}
		}

		internal bool col_Date_finWasSet = false;
		private bool col_Date_finWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_Date_fin = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_Date_fin {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Date_fin);
			}
			set {
			
				this.col_Date_finWasUpdated = true;
				this.col_Date_finWasSet = true;
				this.col_Date_fin = value;
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

		internal bool col_PaieTransporteurWasSet = false;
		private bool col_PaieTransporteurWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_PaieTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_PaieTransporteur {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PaieTransporteur);
			}
			set {
			
				this.col_PaieTransporteurWasUpdated = true;
				this.col_PaieTransporteurWasSet = true;
				this.col_PaieTransporteur = value;
			}
		}

		internal bool col_Taux_SurchargeWasSet = false;
		private bool col_Taux_SurchargeWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux_Surcharge = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux_Surcharge {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux_Surcharge);
			}
			set {
			
				this.col_Taux_SurchargeWasUpdated = true;
				this.col_Taux_SurchargeWasSet = true;
				this.col_Taux_Surcharge = value;
			}
		}

		internal bool col_SurchargeManuelWasSet = false;
		private bool col_SurchargeManuelWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_SurchargeManuel = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_SurchargeManuel {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_SurchargeManuel);
			}
			set {
			
				this.col_SurchargeManuelWasUpdated = true;
				this.col_SurchargeManuelWasSet = true;
				this.col_SurchargeManuel = value;
			}
		}

		internal bool col_TxTransSameProdWasSet = false;
		private bool col_TxTransSameProdWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_TxTransSameProd = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_TxTransSameProd {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_TxTransSameProd);
			}
			set {
			
				this.col_TxTransSameProdWasUpdated = true;
				this.col_TxTransSameProdWasSet = true;
				this.col_TxTransSameProd = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_DescriptionWasUpdated = false;
			this.col_DescriptionWasSet = false;
			this.col_Description = System.Data.SqlTypes.SqlString.Null;

			this.col_UsineIDWasUpdated = false;
			this.col_UsineIDWasSet = false;
			this.col_UsineID = System.Data.SqlTypes.SqlString.Null;

			this.col_AnneeWasUpdated = false;
			this.col_AnneeWasSet = false;
			this.col_Annee = System.Data.SqlTypes.SqlInt32.Null;

			this.col_Date_debutWasUpdated = false;
			this.col_Date_debutWasSet = false;
			this.col_Date_debut = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_Date_finWasUpdated = false;
			this.col_Date_finWasSet = false;
			this.col_Date_fin = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_ActifWasUpdated = false;
			this.col_ActifWasSet = false;
			this.col_Actif = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_PaieTransporteurWasUpdated = false;
			this.col_PaieTransporteurWasSet = false;
			this.col_PaieTransporteur = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_Taux_SurchargeWasUpdated = false;
			this.col_Taux_SurchargeWasSet = false;
			this.col_Taux_Surcharge = System.Data.SqlTypes.SqlDouble.Null;

			this.col_SurchargeManuelWasUpdated = false;
			this.col_SurchargeManuelWasSet = false;
			this.col_SurchargeManuel = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_TxTransSameProdWasUpdated = false;
			this.col_TxTransSameProdWasSet = false;
			this.col_TxTransSameProd = System.Data.SqlTypes.SqlBoolean.Null;

			Params.spS_Contrat Param = new Params.spS_Contrat(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Contrat Sp = new SPs.spS_Contrat();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_Description.ColumnIndex)) {

						this.col_Description = sqlDataReader.GetSqlString(SPs.spS_Contrat.Resultset1.Fields.Column_Description.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_UsineID.ColumnIndex)) {

						this.col_UsineID = sqlDataReader.GetSqlString(SPs.spS_Contrat.Resultset1.Fields.Column_UsineID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_Annee.ColumnIndex)) {

						this.col_Annee = sqlDataReader.GetSqlInt32(SPs.spS_Contrat.Resultset1.Fields.Column_Annee.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_Date_debut.ColumnIndex)) {

						this.col_Date_debut = sqlDataReader.GetSqlDateTime(SPs.spS_Contrat.Resultset1.Fields.Column_Date_debut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_Date_fin.ColumnIndex)) {

						this.col_Date_fin = sqlDataReader.GetSqlDateTime(SPs.spS_Contrat.Resultset1.Fields.Column_Date_fin.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_Actif.ColumnIndex)) {

						this.col_Actif = sqlDataReader.GetSqlBoolean(SPs.spS_Contrat.Resultset1.Fields.Column_Actif.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_PaieTransporteur.ColumnIndex)) {

						this.col_PaieTransporteur = sqlDataReader.GetSqlBoolean(SPs.spS_Contrat.Resultset1.Fields.Column_PaieTransporteur.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_Taux_Surcharge.ColumnIndex)) {

						this.col_Taux_Surcharge = sqlDataReader.GetSqlDouble(SPs.spS_Contrat.Resultset1.Fields.Column_Taux_Surcharge.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_SurchargeManuel.ColumnIndex)) {

						this.col_SurchargeManuel = sqlDataReader.GetSqlBoolean(SPs.spS_Contrat.Resultset1.Fields.Column_SurchargeManuel.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Contrat.Resultset1.Fields.Column_TxTransSameProd.ColumnIndex)) {

						this.col_TxTransSameProd = sqlDataReader.GetSqlBoolean(SPs.spS_Contrat.Resultset1.Fields.Column_TxTransSameProd.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contrat_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UsineIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AnneeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Date_debutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Date_finWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ActifWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PaieTransporteurWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_Taux_SurchargeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_SurchargeManuelWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TxTransSameProdWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Contrat Param = new Params.spU_Contrat(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_DescriptionWasUpdated) {

				Param.Param_Description = this.col_Description;
				Param.Param_ConsiderNull_Description = true;
			}

			if (this.col_UsineIDWasUpdated) {

				Param.Param_UsineID = this.col_UsineID;
				Param.Param_ConsiderNull_UsineID = true;
			}

			if (this.col_AnneeWasUpdated) {

				Param.Param_Annee = this.col_Annee;
				Param.Param_ConsiderNull_Annee = true;
			}

			if (this.col_Date_debutWasUpdated) {

				Param.Param_Date_debut = this.col_Date_debut;
				Param.Param_ConsiderNull_Date_debut = true;
			}

			if (this.col_Date_finWasUpdated) {

				Param.Param_Date_fin = this.col_Date_fin;
				Param.Param_ConsiderNull_Date_fin = true;
			}

			if (this.col_ActifWasUpdated) {

				Param.Param_Actif = this.col_Actif;
				Param.Param_ConsiderNull_Actif = true;
			}

			if (this.col_PaieTransporteurWasUpdated) {

				Param.Param_PaieTransporteur = this.col_PaieTransporteur;
				Param.Param_ConsiderNull_PaieTransporteur = true;
			}

			if (this.col_Taux_SurchargeWasUpdated) {

				Param.Param_Taux_Surcharge = this.col_Taux_Surcharge;
				Param.Param_ConsiderNull_Taux_Surcharge = true;
			}

			if (this.col_SurchargeManuelWasUpdated) {

				Param.Param_SurchargeManuel = this.col_SurchargeManuel;
				Param.Param_ConsiderNull_SurchargeManuel = true;
			}

			if (this.col_TxTransSameProdWasUpdated) {

				Param.Param_TxTransSameProd = this.col_TxTransSameProd;
				Param.Param_ConsiderNull_TxTransSameProd = true;
			}

			SPs.spU_Contrat Sp = new SPs.spU_Contrat();
			if (Sp.Execute(ref Param)) {

				this.col_DescriptionWasUpdated = false;
				this.col_UsineIDWasUpdated = false;
				this.col_AnneeWasUpdated = false;
				this.col_Date_debutWasUpdated = false;
				this.col_Date_finWasUpdated = false;
				this.col_ActifWasUpdated = false;
				this.col_PaieTransporteurWasUpdated = false;
				this.col_Taux_SurchargeWasUpdated = false;
				this.col_SurchargeManuelWasUpdated = false;
				this.col_TxTransSameProdWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contrat_Record", "Update");
			}		
		}

		private Ajustement_Collection internal_Ajustement_Col_ContratID_Collection = null;
		public Ajustement_Collection Ajustement_Col_ContratID_Collection {

			get {

				if (this.internal_Ajustement_Col_ContratID_Collection == null) {

					this.internal_Ajustement_Col_ContratID_Collection = new Ajustement_Collection(this.connectionString);
					this.internal_Ajustement_Col_ContratID_Collection.LoadFrom_ContratID(this.col_ID, this);
				}

				return(this.internal_Ajustement_Col_ContratID_Collection);
			}
		}

		private Contrat_EssenceUnite_Collection internal_Contrat_EssenceUnite_Col_ContratID_Collection = null;
		public Contrat_EssenceUnite_Collection Contrat_EssenceUnite_Col_ContratID_Collection {

			get {

				if (this.internal_Contrat_EssenceUnite_Col_ContratID_Collection == null) {

					this.internal_Contrat_EssenceUnite_Col_ContratID_Collection = new Contrat_EssenceUnite_Collection(this.connectionString);
					this.internal_Contrat_EssenceUnite_Col_ContratID_Collection.LoadFrom_ContratID(this.col_ID, this);
				}

				return(this.internal_Contrat_EssenceUnite_Col_ContratID_Collection);
			}
		}

		private Contrat_Transporteur_Collection internal_Contrat_Transporteur_Col_ContratID_Collection = null;
		public Contrat_Transporteur_Collection Contrat_Transporteur_Col_ContratID_Collection {

			get {

				if (this.internal_Contrat_Transporteur_Col_ContratID_Collection == null) {

					this.internal_Contrat_Transporteur_Col_ContratID_Collection = new Contrat_Transporteur_Collection(this.connectionString);
					this.internal_Contrat_Transporteur_Col_ContratID_Collection.LoadFrom_ContratID(this.col_ID, this);
				}

				return(this.internal_Contrat_Transporteur_Col_ContratID_Collection);
			}
		}

		private Indexation_Collection internal_Indexation_Col_ContratID_Collection = null;
		public Indexation_Collection Indexation_Col_ContratID_Collection {

			get {

				if (this.internal_Indexation_Col_ContratID_Collection == null) {

					this.internal_Indexation_Col_ContratID_Collection = new Indexation_Collection(this.connectionString);
					this.internal_Indexation_Col_ContratID_Collection.LoadFrom_ContratID(this.col_ID, this);
				}

				return(this.internal_Indexation_Col_ContratID_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_ContratID_Collection = null;
		public Livraison_Collection Livraison_Col_ContratID_Collection {

			get {

				if (this.internal_Livraison_Col_ContratID_Collection == null) {

					this.internal_Livraison_Col_ContratID_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_ContratID_Collection.LoadFrom_ContratID(this.col_ID, this);
				}

				return(this.internal_Livraison_Col_ContratID_Collection);
			}
		}

		private Permit_Collection internal_Permit_Col_ContratID_Collection = null;
		public Permit_Collection Permit_Col_ContratID_Collection {

			get {

				if (this.internal_Permit_Col_ContratID_Collection == null) {

					this.internal_Permit_Col_ContratID_Collection = new Permit_Collection(this.connectionString);
					this.internal_Permit_Col_ContratID_Collection.LoadFrom_ContratID(this.col_ID, this);
				}

				return(this.internal_Permit_Col_ContratID_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Contrat_Display Param = new Params.spS_Contrat_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Contrat_Display Sp = new SPs.spS_Contrat_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Contrat_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Contrat_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Contrat_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}

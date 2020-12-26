using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [FactureFournisseur_Details] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.FactureFournisseur_Details_Collection"/> class to do so.
	/// </summary>
	public sealed class FactureFournisseur_Details_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the FactureFournisseur_Details_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.FactureFournisseur_Details_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public FactureFournisseur_Details_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_FactureID">[To be supplied.]</param>
		/// <param name="col_Ligne">[To be supplied.]</param>
		public FactureFournisseur_Details_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_FactureID, System.Data.SqlTypes.SqlInt32 col_Ligne) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FactureFournisseur_Details'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FactureFournisseur_Details", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_FactureID = col_FactureID;
			this.col_Ligne = col_Ligne;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_FactureID {
		
			get {
			
				return(this.col_FactureID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_FactureID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlInt32 col_Ligne = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Ligne {
		
			get {
			
				return(this.col_Ligne);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_Ligne = value;
				}
			}
		}
		
		
		private FactureFournisseur_Record col_FactureID_Record = null;
		public FactureFournisseur_Record Col_FactureID_FactureFournisseur_Record {
		
			get {

				if (this.col_FactureID_Record == null) {
				
					this.col_FactureID_Record = new FactureFournisseur_Record(this.connectionString, this.col_FactureID);
				}
				
				return(this.col_FactureID_Record);
			}
		}

		internal bool col_CompteWasSet = false;
		private bool col_CompteWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_Compte = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Compte);
			}
			set {
			
				this.col_CompteWasUpdated = true;
				this.col_CompteWasSet = true;
				this.col_Compte_Record = null;
				this.col_Compte = value;
			}
		}

		
		private Compte_Record col_Compte_Record = null;
		public Compte_Record Col_Compte_Compte_Record {
		
			get {

				if (this.col_Compte_Record == null) {
				
					this.col_Compte_Record = new Compte_Record(this.connectionString, this.col_Compte);
				}
				
				return(this.col_Compte_Record);
			}
		}

		internal bool col_MontantWasSet = false;
		private bool col_MontantWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant);
			}
			set {
			
				this.col_MontantWasUpdated = true;
				this.col_MontantWasSet = true;
				this.col_Montant = value;
			}
		}

		internal bool col_RefIDWasSet = false;
		private bool col_RefIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_RefID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_RefID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_RefID);
			}
			set {
			
				this.col_RefIDWasUpdated = true;
				this.col_RefIDWasSet = true;
				this.col_RefID = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;


			this.col_CompteWasUpdated = false;
			this.col_CompteWasSet = false;
			this.col_Compte = System.Data.SqlTypes.SqlInt32.Null;

			this.col_MontantWasUpdated = false;
			this.col_MontantWasSet = false;
			this.col_Montant = System.Data.SqlTypes.SqlDouble.Null;

			this.col_RefIDWasUpdated = false;
			this.col_RefIDWasSet = false;
			this.col_RefID = System.Data.SqlTypes.SqlInt32.Null;

			Params.spS_FactureFournisseur_Details Param = new Params.spS_FactureFournisseur_Details(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_FactureID.IsNull) {

				Param.Param_FactureID = this.col_FactureID;
			}

			if (!this.col_Ligne.IsNull) {

				Param.Param_Ligne = this.col_Ligne;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_FactureFournisseur_Details Sp = new SPs.spS_FactureFournisseur_Details();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur_Details.Resultset1.Fields.Column_Compte.ColumnIndex)) {

						this.col_Compte = sqlDataReader.GetSqlInt32(SPs.spS_FactureFournisseur_Details.Resultset1.Fields.Column_Compte.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur_Details.Resultset1.Fields.Column_Montant.ColumnIndex)) {

						this.col_Montant = sqlDataReader.GetSqlDouble(SPs.spS_FactureFournisseur_Details.Resultset1.Fields.Column_Montant.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur_Details.Resultset1.Fields.Column_RefID.ColumnIndex)) {

						this.col_RefID = sqlDataReader.GetSqlInt32(SPs.spS_FactureFournisseur_Details.Resultset1.Fields.Column_RefID.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureFournisseur_Details_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CompteWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MontantWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_RefIDWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_FactureFournisseur_Details Param = new Params.spU_FactureFournisseur_Details(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_FactureID = this.col_FactureID;
			Param.Param_Ligne = this.col_Ligne;

			if (this.col_CompteWasUpdated) {

				Param.Param_Compte = this.col_Compte;
				Param.Param_ConsiderNull_Compte = true;
			}

			if (this.col_MontantWasUpdated) {

				Param.Param_Montant = this.col_Montant;
				Param.Param_ConsiderNull_Montant = true;
			}

			if (this.col_RefIDWasUpdated) {

				Param.Param_RefID = this.col_RefID;
				Param.Param_ConsiderNull_RefID = true;
			}

			SPs.spU_FactureFournisseur_Details Sp = new SPs.spU_FactureFournisseur_Details();
			if (Sp.Execute(ref Param)) {

				this.col_CompteWasUpdated = false;
				this.col_MontantWasUpdated = false;
				this.col_RefIDWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureFournisseur_Details_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_FactureFournisseur_Details_Display Param = new Params.spS_FactureFournisseur_Details_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_FactureID = this.col_FactureID;
				Param.Param_Ligne = this.col_Ligne;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_FactureFournisseur_Details_Display Sp = new SPs.spS_FactureFournisseur_Details_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_FactureFournisseur_Details_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_FactureFournisseur_Details_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FactureFournisseur_Details_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}

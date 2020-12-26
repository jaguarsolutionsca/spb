using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Lot_Proprietaire] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Lot_Proprietaire_Collection"/> class to do so.
	/// </summary>
	public sealed class Lot_Proprietaire_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Lot_Proprietaire_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Lot_Proprietaire_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Lot_Proprietaire_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ProprietaireID">[To be supplied.]</param>
		/// <param name="col_DateDebut">[To be supplied.]</param>
		/// <param name="col_LotID">[To be supplied.]</param>
		public Lot_Proprietaire_Record(string connectionString, System.Data.SqlTypes.SqlString col_ProprietaireID, System.Data.SqlTypes.SqlDateTime col_DateDebut, System.Data.SqlTypes.SqlInt32 col_LotID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Lot_Proprietaire'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Lot_Proprietaire", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ProprietaireID = col_ProprietaireID;
			this.col_DateDebut = col_DateDebut;
			this.col_LotID = col_LotID;
		}
		
		internal System.Data.SqlTypes.SqlString col_ProprietaireID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProprietaireID {
		
			get {
			
				return(this.col_ProprietaireID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ProprietaireID = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlDateTime col_DateDebut = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateDebut {
		
			get {
			
				return(this.col_DateDebut);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_DateDebut = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlInt32 col_LotID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LotID {
		
			get {
			
				return(this.col_LotID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_LotID = value;
				}
			}
		}
		
		
		private Fournisseur_Record col_ProprietaireID_Record = null;
		public Fournisseur_Record Col_ProprietaireID_Fournisseur_Record {
		
			get {

				if (this.col_ProprietaireID_Record == null) {
				
					this.col_ProprietaireID_Record = new Fournisseur_Record(this.connectionString, this.col_ProprietaireID);
				}
				
				return(this.col_ProprietaireID_Record);
			}
		}

		internal bool col_DateFinWasSet = false;
		private bool col_DateFinWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateFin = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateFin {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateFin);
			}
			set {
			
				this.col_DateFinWasUpdated = true;
				this.col_DateFinWasSet = true;
				this.col_DateFin = value;
			}
		}

		
		private Lot_Record col_LotID_Record = null;
		public Lot_Record Col_LotID_Lot_Record {
		
			get {

				if (this.col_LotID_Record == null) {
				
					this.col_LotID_Record = new Lot_Record(this.connectionString, this.col_LotID);
				}
				
				return(this.col_LotID_Record);
			}
		}


		public bool Refresh() {

			this.displayName = null;


			this.col_DateFinWasUpdated = false;
			this.col_DateFinWasSet = false;
			this.col_DateFin = System.Data.SqlTypes.SqlDateTime.Null;


			Params.spS_Lot_Proprietaire Param = new Params.spS_Lot_Proprietaire(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ProprietaireID.IsNull) {

				Param.Param_ProprietaireID = this.col_ProprietaireID;
			}

			if (!this.col_DateDebut.IsNull) {

				Param.Param_DateDebut = this.col_DateDebut;
			}

			if (!this.col_LotID.IsNull) {

				Param.Param_LotID = this.col_LotID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Lot_Proprietaire Sp = new SPs.spS_Lot_Proprietaire();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Lot_Proprietaire.Resultset1.Fields.Column_DateFin.ColumnIndex)) {

						this.col_DateFin = sqlDataReader.GetSqlDateTime(SPs.spS_Lot_Proprietaire.Resultset1.Fields.Column_DateFin.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Lot_Proprietaire_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateFinWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Lot_Proprietaire Param = new Params.spU_Lot_Proprietaire(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ProprietaireID = this.col_ProprietaireID;
			Param.Param_DateDebut = this.col_DateDebut;
			Param.Param_LotID = this.col_LotID;

			if (this.col_DateFinWasUpdated) {

				Param.Param_DateFin = this.col_DateFin;
				Param.Param_ConsiderNull_DateFin = true;
			}

			SPs.spU_Lot_Proprietaire Sp = new SPs.spU_Lot_Proprietaire();
			if (Sp.Execute(ref Param)) {

				this.col_DateFinWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Lot_Proprietaire_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Lot_Proprietaire_Display Param = new Params.spS_Lot_Proprietaire_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ProprietaireID = this.col_ProprietaireID;
				Param.Param_DateDebut = this.col_DateDebut;
				Param.Param_LotID = this.col_LotID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Lot_Proprietaire_Display Sp = new SPs.spS_Lot_Proprietaire_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Lot_Proprietaire_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Lot_Proprietaire_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Lot_Proprietaire_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}

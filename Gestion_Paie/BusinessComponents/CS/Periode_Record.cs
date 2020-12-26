using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [Periode] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.Periode_Collection"/> class to do so.
	/// </summary>
	public sealed class Periode_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the Periode_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.Periode_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public Periode_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_Annee">[To be supplied.]</param>
		/// <param name="col_SemaineNo">[To be supplied.]</param>
		public Periode_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_Annee, System.Data.SqlTypes.SqlInt32 col_SemaineNo) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Periode'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Periode", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_Annee = col_Annee;
			this.col_SemaineNo = col_SemaineNo;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_Annee = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Annee {
		
			get {
			
				return(this.col_Annee);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_Annee = value;
				}
			}
		}
		internal System.Data.SqlTypes.SqlInt32 col_SemaineNo = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_SemaineNo {
		
			get {
			
				return(this.col_SemaineNo);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_SemaineNo = value;
				}
			}
		}
		
		internal bool col_DateDebutWasSet = false;
		private bool col_DateDebutWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateDebut = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateDebut {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateDebut);
			}
			set {
			
				this.col_DateDebutWasUpdated = true;
				this.col_DateDebutWasSet = true;
				this.col_DateDebut = value;
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

		internal bool col_PeriodeContingentementWasSet = false;
		private bool col_PeriodeContingentementWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_PeriodeContingentement = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_PeriodeContingentement {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_PeriodeContingentement);
			}
			set {
			
				this.col_PeriodeContingentementWasUpdated = true;
				this.col_PeriodeContingentementWasSet = true;
				this.col_PeriodeContingentement = value;
			}
		}


		public bool Refresh() {

			this.displayName = null;


			this.col_DateDebutWasUpdated = false;
			this.col_DateDebutWasSet = false;
			this.col_DateDebut = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_DateFinWasUpdated = false;
			this.col_DateFinWasSet = false;
			this.col_DateFin = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_PeriodeContingentementWasUpdated = false;
			this.col_PeriodeContingentementWasSet = false;
			this.col_PeriodeContingentement = System.Data.SqlTypes.SqlInt32.Null;

			Params.spS_Periode Param = new Params.spS_Periode(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_Annee.IsNull) {

				Param.Param_Annee = this.col_Annee;
			}

			if (!this.col_SemaineNo.IsNull) {

				Param.Param_SemaineNo = this.col_SemaineNo;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Periode Sp = new SPs.spS_Periode();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_Periode.Resultset1.Fields.Column_DateDebut.ColumnIndex)) {

						this.col_DateDebut = sqlDataReader.GetSqlDateTime(SPs.spS_Periode.Resultset1.Fields.Column_DateDebut.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Periode.Resultset1.Fields.Column_DateFin.ColumnIndex)) {

						this.col_DateFin = sqlDataReader.GetSqlDateTime(SPs.spS_Periode.Resultset1.Fields.Column_DateFin.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_Periode.Resultset1.Fields.Column_PeriodeContingentement.ColumnIndex)) {

						this.col_PeriodeContingentement = sqlDataReader.GetSqlInt32(SPs.spS_Periode.Resultset1.Fields.Column_PeriodeContingentement.ColumnIndex);
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

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Periode_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateDebutWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateFinWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_PeriodeContingentementWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_Periode Param = new Params.spU_Periode(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_Annee = this.col_Annee;
			Param.Param_SemaineNo = this.col_SemaineNo;

			if (this.col_DateDebutWasUpdated) {

				Param.Param_DateDebut = this.col_DateDebut;
				Param.Param_ConsiderNull_DateDebut = true;
			}

			if (this.col_DateFinWasUpdated) {

				Param.Param_DateFin = this.col_DateFin;
				Param.Param_ConsiderNull_DateFin = true;
			}

			if (this.col_PeriodeContingentementWasUpdated) {

				Param.Param_PeriodeContingentement = this.col_PeriodeContingentement;
				Param.Param_ConsiderNull_PeriodeContingentement = true;
			}

			SPs.spU_Periode Sp = new SPs.spU_Periode();
			if (Sp.Execute(ref Param)) {

				this.col_DateDebutWasUpdated = false;
				this.col_DateFinWasUpdated = false;
				this.col_PeriodeContingentementWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Periode_Record", "Update");
			}		
		}

		private Livraison_Collection internal_Livraison_Col_Annee_Collection = null;
		public Livraison_Collection Livraison_Col_Annee_Collection {

			get {

				if (this.internal_Livraison_Col_Annee_Collection == null) {

					this.internal_Livraison_Col_Annee_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_Annee_Collection.LoadFrom_Annee(this.col_Annee, this);
				}

				return(this.internal_Livraison_Col_Annee_Collection);
			}
		}

		private Livraison_Collection internal_Livraison_Col_Periode_Collection = null;
		public Livraison_Collection Livraison_Col_Periode_Collection {

			get {

				if (this.internal_Livraison_Col_Periode_Collection == null) {

					this.internal_Livraison_Col_Periode_Collection = new Livraison_Collection(this.connectionString);
					this.internal_Livraison_Col_Periode_Collection.LoadFrom_Periode(this.col_SemaineNo, this);
				}

				return(this.internal_Livraison_Col_Periode_Collection);
			}
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_Periode_Display Param = new Params.spS_Periode_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_Annee = this.col_Annee;
				Param.Param_SemaineNo = this.col_SemaineNo;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_Periode_Display Sp = new SPs.spS_Periode_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_Periode_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_Periode_Display";
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

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Periode_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}

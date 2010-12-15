#region License

/*
 * Copyright � 2002-2010 the original author or authors.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

#region Imports

using System;
using System.Runtime.Serialization;
using Spring.Dao;

#endregion

namespace Spring.Data
{
	/// <summary>
    /// Exception thrown when an attempt to insert or update data
    /// results in violation of an primary key or unique constraint.
    /// Note that this is not necessarily a purely relational concept;
    /// unique primary keys are required by most database types.
	/// </summary>
	/// <author>Thomas Risberg</author>
	/// <author>Mark Pollack (.NET)</author>
	[Serializable]
	public class DuplicateKeyException : DataIntegrityViolationException
	{
		#region Fields

        /// <summary>
        /// SQL that led to the problem
        /// </summary>
        private string sql;

		#endregion

		#region Constructor (s)
		/// <summary>
		/// Initializes a new instance of the <see cref="DuplicateKeyException"/> class.
        /// </summary>
		public DuplicateKeyException()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateKeyException"/> class.
        /// </summary>
        /// <param name="message">A message about the exception.</param>
        public DuplicateKeyException(string message): base(message)
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateKeyException"/> class.
        /// </summary>
        /// <param name="message">A message about the exception.</param>
        /// <param name="inner">The inner exception.</param>
        public DuplicateKeyException(string message, Exception inner): base(message, inner)
        {            
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateKeyException"/> class.
        /// </summary>
        /// <param name="task">name of the current task.</param>
        /// <param name="sql">The offending SQL statment</param>
        /// <param name="ex">The root cause.</param>
        public DuplicateKeyException(string task, String sql, Exception ex) : base(task + "; Duplicate key for SQL [" + sql + "]; " + ex.Message, ex)           
        {
             this.sql = sql;
        }
        /// <summary>
        /// Creates a new instance of the
        /// <see cref="DuplicateKeyException"/> class.
        /// </summary>
        /// <param name="info">
        /// The <see cref="System.Runtime.Serialization.SerializationInfo"/>
        /// that holds the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="System.Runtime.Serialization.StreamingContext"/>
        /// that contains contextual information about the source or destination.
        /// </param>
        protected DuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context) { }



		#endregion

		#region Properties

        /// <summary>
        /// Gets the SQL that caused the exception
        /// </summary>
        /// <value>The SQL that caused the exception.</value>
	    public string Sql
	    {
            get 
            {
                return sql;
            }
	    }
		#endregion

		#region Methods

		#endregion

        #region ISerializable Members

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"/>
        /// with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is a null reference (<see langword="Nothing"/> in Visual Basic).</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue( "sql", sql );
            base.GetObjectData( info, context ); 
        }

        #endregion
    }
}

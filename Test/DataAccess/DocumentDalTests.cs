using CaseAPI.DataAccess.Concretes;
using CaseAPI.Models;
using CaseAPI.Models.caseproj;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccess
{
    public class DocumentDalTests
    {
        private readonly UnitOfWork _uow;
        private readonly DocumentDal _documentDal;
        public DocumentDalTests() 
        {
            var dataStore = new SimpleDataLayer(new InMemoryDataStore());
            _uow = new UnitOfWork(dataStore);
            _documentDal = new DocumentDal(_uow);
        }

        [Fact]
        public void DocumentDal_GetAll_Collection()
        {
            ICollection<Document> result = _documentDal.GetAll();
            Assert.NotNull(result);
        }

        [Fact]
        public void DocumentDal_Get_Collection()
        {
            CreateExample();
            Document result = _documentDal.Get((d) => d.Name == "Test");
            Assert.NotNull(result);
        }

        [Fact]
        public void DocumentDal_Save_Void()
        {
            CreateExample();
            Document createdDocument = new XPQuery<Document>(_uow).SingleOrDefault((d) => d.Name == "Test");
            Assert.Equal(createdDocument.Name, "Test");
        }

        [Fact]
        public void DocumentDal_Delete_Void()
        {
            Document document = CreateExample();
            _documentDal.Delete(document);
            Document updatedDocument = new XPQuery<Document>(_uow).SingleOrDefault((d) => d.Name == "Test");
            Assert.Null(updatedDocument);
        }

        [Fact]
        public void DocumentDal_CreateObject_Document()
        {
            Document document = _documentDal.CreateObject();
            Assert.NotNull(document);
        }

        private Document CreateExample()
        {
            Document document = new Document(_uow);
            document.Name = "Test";
            _uow.CommitChanges();
            return document;
        }

    }
}

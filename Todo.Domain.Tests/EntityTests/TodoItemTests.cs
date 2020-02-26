using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _validTodo = new TodoItem("Titulo aqui", "MarcosWOC", DateTime.Now);

        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
            var todo = new TodoItem("Titulo aqui", "MarcosWOC", DateTime.Now);
            Assert.AreEqual(_validTodo.Done, false);
        }   
    }
}
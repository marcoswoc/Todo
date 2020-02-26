using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers.Contracts
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>
        
    {
        private readonly ITodoRepository _repository;
        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada!",
                    command.Notifications
                );

            //Gera o TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date);

            //Salva no banco
            _repository.Create(todo);

            //Retorna o resultado
            return new GenericCommandResult(
                true,
                "Tarefa salva",
                todo
            );

        }

    }
}
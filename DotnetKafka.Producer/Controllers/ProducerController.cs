using DotnetKafka.Entities;
using DotnetKafka.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotnetKafka.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProducerController : ControllerBase
{
    private readonly IMessageRepository _service;

    public ProducerController(IMessageRepository service)
    {
        _service = service;
    }

    [HttpPost]
    public void AddMensagem(MessageProducer mensagem)
    {
        _service.SendMessage(mensagem);
    }
}
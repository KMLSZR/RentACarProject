﻿using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.Create;

public class CreatedOperationClaimResponse 
{
    public int Id { get; set; }
    public string Name { get; set; }
}

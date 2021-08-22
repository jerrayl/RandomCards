import { Body, Controller, Delete, Get, Post, Put, Query, Route, Tags } from 'tsoa';
import { getAllModifierTypes, manualSeeding } from './card.service';

@Tags('Cards')
@Route('/api/cards')
export class CardController extends Controller {

  @Get('/get-all/')
  public async getAllModifierTypes() {
    return getAllModifierTypes()
  }

  @Post('/manual-seed/')
  public async manualSeeding() {
    return manualSeeding()
  }

}


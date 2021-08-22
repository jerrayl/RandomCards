import { Card } from '@entity/card';
import { Modifier } from '@entity/modifier';
import { ModifierType } from '@entity/modifierType';
import { ModifierTypeSeed } from 'src/seed/modifierType.seed';
import { getRepository } from 'typeorm';

export const getAllModifierTypes = async () => {
  try {
    return await ModifierType.find();
  } catch (e) {
    console.error(e);
  }
}

export const manualSeeding = async () => {
  try {
    const modifierTypeResult = await getRepository(ModifierType).save(
      ModifierTypeSeed
    )
  } catch (e) {
    console.error(e);
  }
}
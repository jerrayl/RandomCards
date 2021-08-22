import { Entity, PrimaryGeneratedColumn, Column, BaseEntity, ManyToOne } from "typeorm";
import { Card } from "./card";
import { ModifierType } from "./modifierType";

@Entity({ name: 'modifier' })
export class Modifier extends BaseEntity {

  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  effect: number;

  @ManyToOne(() => Card, (card: Card) => card.modifiers, { onDelete: 'CASCADE' })
  card: Card;

  @ManyToOne(() => ModifierType, (modifierType: ModifierType) => modifierType.modifiers, { onDelete: 'CASCADE' })
  modifierType: ModifierType;

}
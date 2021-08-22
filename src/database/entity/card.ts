import { Entity, PrimaryGeneratedColumn, Column, BaseEntity, OneToMany, ManyToOne } from "typeorm";
import { Deck } from "./deck";
import { Modifier } from "./modifier";

@Entity({ name: 'card' })
export class Card extends BaseEntity {

  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  name: string;

  @Column()
  mana: number;

  @Column()
  image: string;

  @Column()
  flavorText: string;

  @OneToMany(() => Modifier, (modifier: Modifier) => modifier.card, { onDelete: 'CASCADE' })
  modifiers: Modifier[];

  @ManyToOne(() => Deck, (deck: Deck) => deck.cards, { onDelete: 'CASCADE' })
  deck: Deck;

}
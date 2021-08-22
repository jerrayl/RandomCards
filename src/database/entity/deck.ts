import { Entity, PrimaryGeneratedColumn, Column, BaseEntity, ManyToOne, OneToMany } from "typeorm";
import { Account } from "./account";
import { Card } from "./card";
import { GameClass } from "./gameClass";

@Entity({ name: 'deck' })
export class Deck extends BaseEntity {

  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  name: string;

  @ManyToOne(() => GameClass, (gameClass: GameClass) => gameClass.decks, { onDelete: 'CASCADE' })
  class: GameClass;

  @ManyToOne(() => Account, (account: Account) => account.decks, { onDelete: 'CASCADE' })
  account: Account;

  @OneToMany(() => Card, (card: Card) => card.deck, {onDelete: "CASCADE"})
  cards: Card[];

}
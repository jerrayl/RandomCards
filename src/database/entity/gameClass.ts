import { Entity, PrimaryGeneratedColumn, Column, BaseEntity, OneToMany } from "typeorm";
import { Deck } from "./deck";

@Entity({ name: 'gameClass' })
export class GameClass extends BaseEntity {

  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  name: string;

  @OneToMany(() => Deck, (deck: Deck) => deck.class, { onDelete: 'CASCADE' })
  decks: Deck[];

}
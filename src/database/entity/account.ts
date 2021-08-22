import { Entity, PrimaryGeneratedColumn, Column, BaseEntity, OneToMany } from "typeorm";
import { Deck } from "./deck";
import { PlayerSession } from "./playerSession";

@Entity({ name: 'account' })
export class Account extends BaseEntity {

  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  emailAddress: string;

  @OneToMany(() => Deck, (deck: Deck) => deck.account, { onDelete: 'CASCADE' })
  decks: Deck[];

  @OneToMany(() => PlayerSession, (playerSession: PlayerSession) => playerSession.account, { onDelete: 'CASCADE' })
  playerSessions: PlayerSession[];

}
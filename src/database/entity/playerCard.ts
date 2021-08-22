import { Entity, PrimaryGeneratedColumn, Column, BaseEntity, ManyToOne } from "typeorm";
import { PlayerSession } from "./playerSession";

@Entity({ name: 'playerCard' })
export class PlayerCard extends BaseEntity {

  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  status: 'hand' | 'deck' | 'discard';
  
  @ManyToOne(() => PlayerSession, (playerSession: PlayerSession) => playerSession.cards, { onDelete: 'CASCADE' })
  playerSession: PlayerSession;

}
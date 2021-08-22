import { Entity, PrimaryGeneratedColumn, Column, BaseEntity, ManyToOne, OneToMany } from "typeorm";
import { Account } from "./account";
import { PlayerCard } from "./playerCard";
import { GameRoom } from "./gameRoom";

@Entity({ name: 'playerSession' })
export class PlayerSession extends BaseEntity {

  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  token: string;

  @Column()
  expiresAt: Date;

  @Column()
  maxHealth: number;

  @Column()
  health: number;

  @Column()
  maxMana: number;

  @Column()
  mana: number;

  @Column()
  manaScaling: number;

  @Column()
  maxArmor: number;
  
  @Column()
  armor: number;

  @Column()
  statuses: number;

  @OneToMany(() => PlayerCard, (playerCard: PlayerCard) => playerCard.playerSession, { onDelete: 'CASCADE' })
  cards: PlayerCard[];

  @ManyToOne(() => Account, (account: Account) => account.playerSessions, { onDelete: 'CASCADE' })
  account: Account;

  @ManyToOne(() => GameRoom, (gameRoom: GameRoom) => gameRoom.players, { onDelete: 'CASCADE' })
  gameRoom: GameRoom;

}
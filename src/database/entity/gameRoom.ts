import { Entity, PrimaryGeneratedColumn, Column, BaseEntity, OneToMany, OneToOne} from "typeorm";
import { PlayerSession } from "./playerSession";

@Entity({ name: 'gameRoom' })
export class GameRoom extends BaseEntity {

  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  code: string;

  @Column()
  status: string;

  @OneToOne(() => PlayerSession, { onDelete: 'CASCADE' })
  currentPlayer: PlayerSession;

  @OneToMany(() => PlayerSession, (playerSession: PlayerSession) => playerSession.account, { onDelete: 'CASCADE' })
  players: PlayerSession[];

}
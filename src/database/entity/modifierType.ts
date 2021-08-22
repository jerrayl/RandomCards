import { Entity, PrimaryGeneratedColumn, Column, BaseEntity, OneToMany } from "typeorm";
import { Modifier } from "./modifier";

@Entity({ name: 'modifierType' })
export class ModifierType extends BaseEntity {

  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  name: string;

  @Column()
  value: number;

  @Column()
  rarity: number;

  @Column()
  description: string;

  @Column("simple-array")
  tags: string[];

  @Column()
  flavorText: string;

  @Column("simple-json")
  aliases: { adj: string, verb: string, concept: string, object: string, creature: string };

  @OneToMany(() => Modifier, (modifier: Modifier) => modifier.modifierType, { onDelete: 'CASCADE' })
  modifiers: Modifier;

}
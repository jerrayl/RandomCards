import { getRepository, MigrationInterface, QueryRunner } from "typeorm";
import { ModifierTypeSeed } from "src/seed/modifierType.seed";
import { ModifierType } from "@entity/modifierType";

export class Seed1629629569936 implements MigrationInterface {

    public async up(queryRunner: QueryRunner): Promise<void> {
        const modifierTypeResult = await getRepository(ModifierType).save(
            ModifierTypeSeed
        );
    }

    public async down(queryRunner: QueryRunner): Promise<void> {
    }

}

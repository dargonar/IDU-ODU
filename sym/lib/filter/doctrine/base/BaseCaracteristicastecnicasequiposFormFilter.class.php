<?php

/**
 * Caracteristicastecnicasequipos filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseCaracteristicastecnicasequiposFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'caracteristicastecnicasequipos_version'               => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_descripcion1'          => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_descripcion2'          => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_descripcion3'          => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_descripcion4'          => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_descripcion5'          => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_descripcion6'          => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_tensionnominal'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_frecuencia'            => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_potenciamaxima'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_corrientemaxima'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_carga'                 => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_presion'               => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_capacidadfrio'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_potencianominalfrio'   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_corrientenominalfrio'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_peso'                  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_capacidadcalor'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_potencianominalcalor'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_corrientenominalcalor' => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_err'                   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_esidu'                 => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_nombre'                => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Modelos'), 'add_empty' => true)),
      'caracteristicastecnicasequipos_idparametros'          => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'caracteristicastecnicasequipos_idparametros_idu'      => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Parametrosensayosidu'), 'add_empty' => true)),
      'caracteristicastecnicasequipos_idparametros_odu'      => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Parametrosensayosodu'), 'add_empty' => true)),
      'es_activo'                                            => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'id'                                                   => new sfWidgetFormFilterInput(),
    ));

    $this->setValidators(array(
      'caracteristicastecnicasequipos_version'               => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'caracteristicastecnicasequipos_descripcion1'          => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_descripcion2'          => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_descripcion3'          => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_descripcion4'          => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_descripcion5'          => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_descripcion6'          => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_tensionnominal'        => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_frecuencia'            => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_potenciamaxima'        => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_corrientemaxima'       => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_carga'                 => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_presion'               => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_capacidadfrio'         => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_potencianominalfrio'   => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_corrientenominalfrio'  => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_peso'                  => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_capacidadcalor'        => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_potencianominalcalor'  => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_corrientenominalcalor' => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_err'                   => new sfValidatorPass(array('required' => false)),
      'caracteristicastecnicasequipos_esidu'                 => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'caracteristicastecnicasequipos_nombre'                => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('Modelos'), 'column' => 'modelos_id')),
      'caracteristicastecnicasequipos_idparametros'          => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'caracteristicastecnicasequipos_idparametros_idu'      => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('Parametrosensayosidu'), 'column' => 'parametrosensayosidu_id')),
      'caracteristicastecnicasequipos_idparametros_odu'      => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('Parametrosensayosodu'), 'column' => 'parametrosensayosodu_id')),
      'es_activo'                                            => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'id'                                                   => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
    ));

    $this->widgetSchema->setNameFormat('caracteristicastecnicasequipos_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Caracteristicastecnicasequipos';
  }

  public function getFields()
  {
    return array(
      'caracteristicastecnicasequipos_id'                    => 'Number',
      'caracteristicastecnicasequipos_version'               => 'Number',
      'caracteristicastecnicasequipos_descripcion1'          => 'Text',
      'caracteristicastecnicasequipos_descripcion2'          => 'Text',
      'caracteristicastecnicasequipos_descripcion3'          => 'Text',
      'caracteristicastecnicasequipos_descripcion4'          => 'Text',
      'caracteristicastecnicasequipos_descripcion5'          => 'Text',
      'caracteristicastecnicasequipos_descripcion6'          => 'Text',
      'caracteristicastecnicasequipos_tensionnominal'        => 'Text',
      'caracteristicastecnicasequipos_frecuencia'            => 'Text',
      'caracteristicastecnicasequipos_potenciamaxima'        => 'Text',
      'caracteristicastecnicasequipos_corrientemaxima'       => 'Text',
      'caracteristicastecnicasequipos_carga'                 => 'Text',
      'caracteristicastecnicasequipos_presion'               => 'Text',
      'caracteristicastecnicasequipos_capacidadfrio'         => 'Text',
      'caracteristicastecnicasequipos_potencianominalfrio'   => 'Text',
      'caracteristicastecnicasequipos_corrientenominalfrio'  => 'Text',
      'caracteristicastecnicasequipos_peso'                  => 'Text',
      'caracteristicastecnicasequipos_capacidadcalor'        => 'Text',
      'caracteristicastecnicasequipos_potencianominalcalor'  => 'Text',
      'caracteristicastecnicasequipos_corrientenominalcalor' => 'Text',
      'caracteristicastecnicasequipos_err'                   => 'Text',
      'caracteristicastecnicasequipos_esidu'                 => 'Number',
      'caracteristicastecnicasequipos_nombre'                => 'ForeignKey',
      'caracteristicastecnicasequipos_idparametros'          => 'Number',
      'caracteristicastecnicasequipos_idparametros_idu'      => 'ForeignKey',
      'caracteristicastecnicasequipos_idparametros_odu'      => 'ForeignKey',
      'es_activo'                                            => 'Number',
      'id'                                                   => 'Number',
    );
  }
}

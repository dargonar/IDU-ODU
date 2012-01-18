<?php

/**
 * Caracteristicastecnicasequipos form base class.
 *
 * @method Caracteristicastecnicasequipos getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseCaracteristicastecnicasequiposForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'caracteristicastecnicasequipos_id'                    => new sfWidgetFormInputHidden(),
      'caracteristicastecnicasequipos_version'               => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_descripcion1'          => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_descripcion2'          => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_descripcion3'          => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_descripcion4'          => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_descripcion5'          => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_descripcion6'          => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_tensionnominal'        => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_frecuencia'            => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_potenciamaxima'        => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_corrientemaxima'       => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_carga'                 => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_presion'               => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_capacidadfrio'         => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_potencianominalfrio'   => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_corrientenominalfrio'  => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_peso'                  => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_capacidadcalor'        => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_potencianominalcalor'  => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_corrientenominalcalor' => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_err'                   => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_esidu'                 => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_nombre'                => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Modelos'), 'add_empty' => false)),
      'caracteristicastecnicasequipos_idparametros'          => new sfWidgetFormInputText(),
      'caracteristicastecnicasequipos_idparametros_idu'      => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Parametrosensayosidu'), 'add_empty' => true)),
      'caracteristicastecnicasequipos_idparametros_odu'      => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Parametrosensayosodu'), 'add_empty' => true)),
      'es_activo'                                            => new sfWidgetFormInputText(),
      'id'                                                   => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'caracteristicastecnicasequipos_id'                    => new sfValidatorChoice(array('choices' => array($this->getObject()->get('caracteristicastecnicasequipos_id')), 'empty_value' => $this->getObject()->get('caracteristicastecnicasequipos_id'), 'required' => false)),
      'caracteristicastecnicasequipos_version'               => new sfValidatorInteger(array('required' => false)),
      'caracteristicastecnicasequipos_descripcion1'          => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_descripcion2'          => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_descripcion3'          => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_descripcion4'          => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_descripcion5'          => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_descripcion6'          => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_tensionnominal'        => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_frecuencia'            => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_potenciamaxima'        => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_corrientemaxima'       => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_carga'                 => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_presion'               => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_capacidadfrio'         => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_potencianominalfrio'   => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_corrientenominalfrio'  => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_peso'                  => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_capacidadcalor'        => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_potencianominalcalor'  => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_corrientenominalcalor' => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_err'                   => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'caracteristicastecnicasequipos_esidu'                 => new sfValidatorInteger(array('required' => false)),
      'caracteristicastecnicasequipos_nombre'                => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Modelos'))),
      'caracteristicastecnicasequipos_idparametros'          => new sfValidatorInteger(),
      'caracteristicastecnicasequipos_idparametros_idu'      => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Parametrosensayosidu'), 'required' => false)),
      'caracteristicastecnicasequipos_idparametros_odu'      => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Parametrosensayosodu'), 'required' => false)),
      'es_activo'                                            => new sfValidatorInteger(array('required' => false)),
      'id'                                                   => new sfValidatorInteger(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('caracteristicastecnicasequipos[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Caracteristicastecnicasequipos';
  }

}

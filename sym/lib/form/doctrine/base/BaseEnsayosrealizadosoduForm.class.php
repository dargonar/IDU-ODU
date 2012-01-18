<?php

/**
 * Ensayosrealizadosodu form base class.
 *
 * @method Ensayosrealizadosodu getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseEnsayosrealizadosoduForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'ensayosrealizadosodu_id'                       => new sfWidgetFormInputHidden(),
      'ensayosrealizadosodu_marca'                    => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_modelo'                   => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_codigo'                   => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_serie'                    => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_fecha'                    => new sfWidgetFormDateTime(),
      'ensayosrealizadosodu_aprobado'                 => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_dcf'                      => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_diferenciadetemperatura'  => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_temperaturaambiente'      => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_humedad'                  => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_tensionalta'              => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_tensionbaja'              => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_corrientealta'            => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_corrientebaja'            => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_potenciaalta'             => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_factordepotencia'         => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_velocidadalta'            => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_velocidadbaja'            => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_presioninicial'           => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_presionbajatension'       => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_presionensayo'            => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_presionrecuperacion'      => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_flags'                    => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_tensionaltacalor'         => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_corrientealtacalor'       => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_factordepotenciacalor'    => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_potenciaaltacalor'        => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_velocidadaltacalor'       => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_temperaturaaltacalor'     => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_temperaturaambientecalor' => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_humedadcalor'             => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_presionbajatensioncalor'  => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_vacio'                    => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_hipot'                    => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_fuga'                     => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_observaciones'            => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_tiempoensayo'             => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_cantidadreimpresion'      => new sfWidgetFormInputText(),
      'ensayosrealizadosodu_usuario'                  => new sfWidgetFormInputText(),
      'orden_fabricacion'                             => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'ensayosrealizadosodu_id'                       => new sfValidatorChoice(array('choices' => array($this->getObject()->get('ensayosrealizadosodu_id')), 'empty_value' => $this->getObject()->get('ensayosrealizadosodu_id'), 'required' => false)),
      'ensayosrealizadosodu_marca'                    => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'ensayosrealizadosodu_modelo'                   => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'ensayosrealizadosodu_codigo'                   => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'ensayosrealizadosodu_serie'                    => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'ensayosrealizadosodu_fecha'                    => new sfValidatorDateTime(array('required' => false)),
      'ensayosrealizadosodu_aprobado'                 => new sfValidatorInteger(array('required' => false)),
      'ensayosrealizadosodu_dcf'                      => new sfValidatorString(array('max_length' => 10, 'required' => false)),
      'ensayosrealizadosodu_diferenciadetemperatura'  => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_temperaturaambiente'      => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_humedad'                  => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_tensionalta'              => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_tensionbaja'              => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_corrientealta'            => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_corrientebaja'            => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_potenciaalta'             => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_factordepotencia'         => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_velocidadalta'            => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_velocidadbaja'            => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_presioninicial'           => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_presionbajatension'       => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_presionensayo'            => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_presionrecuperacion'      => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_flags'                    => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_tensionaltacalor'         => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_corrientealtacalor'       => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_factordepotenciacalor'    => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_potenciaaltacalor'        => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_velocidadaltacalor'       => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_temperaturaaltacalor'     => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_temperaturaambientecalor' => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_humedadcalor'             => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_presionbajatensioncalor'  => new sfValidatorNumber(array('required' => false)),
      'ensayosrealizadosodu_vacio'                    => new sfValidatorString(array('max_length' => 100)),
      'ensayosrealizadosodu_hipot'                    => new sfValidatorString(array('max_length' => 100)),
      'ensayosrealizadosodu_fuga'                     => new sfValidatorString(array('max_length' => 100)),
      'ensayosrealizadosodu_observaciones'            => new sfValidatorString(array('max_length' => 100)),
      'ensayosrealizadosodu_tiempoensayo'             => new sfValidatorInteger(),
      'ensayosrealizadosodu_cantidadreimpresion'      => new sfValidatorInteger(array('required' => false)),
      'ensayosrealizadosodu_usuario'                  => new sfValidatorString(array('max_length' => 45)),
      'orden_fabricacion'                             => new sfValidatorString(array('max_length' => 255, 'required' => false)),
    ));

    $this->widgetSchema->setNameFormat('ensayosrealizadosodu[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Ensayosrealizadosodu';
  }

}

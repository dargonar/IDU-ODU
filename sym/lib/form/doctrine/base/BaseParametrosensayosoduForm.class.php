<?php

/**
 * Parametrosensayosodu form base class.
 *
 * @method Parametrosensayosodu getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseParametrosensayosoduForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'parametrosensayosodu_id'                             => new sfWidgetFormInputHidden(),
      'parametrosensayosodu_ref'                            => new sfWidgetFormInputText(),
      'parametrosensayosodu_descripcion'                    => new sfWidgetFormInputText(),
      'parametrosensayosodu_modificado'                     => new sfWidgetFormDateTime(),
      'parametrosensayosodu_dcfs'                           => new sfWidgetFormInputText(),
      'parametrosensayosodu_tiempoinicialestabilizacion'    => new sfWidgetFormInputText(),
      'parametrosensayosodu_tiempomaximoestabilizacion'     => new sfWidgetFormInputText(),
      'parametrosensayosodu_tiempobajatension'              => new sfWidgetFormInputText(),
      'parametrosensayosodu_tiempomaximobajatension'        => new sfWidgetFormInputText(),
      'parametrosensayosodu_tiempomedicioncalor'            => new sfWidgetFormInputText(),
      'parametrosensayosodu_tiempomaximomedicioncalor'      => new sfWidgetFormInputText(),
      'parametrosensayosodu_tiempomedicionfrio'             => new sfWidgetFormInputText(),
      'parametrosensayosodu_tiemporecuperacionminima'       => new sfWidgetFormInputText(),
      'parametrosensayosodu_tiempomaximorecuperacionminima' => new sfWidgetFormInputText(),
      'parametrosensayosodu_delayarranquecompresor'         => new sfWidgetFormInputText(),
      'parametrosensayosodu_tiempoapagadoentrecaloryfrio'   => new sfWidgetFormInputText(),
      'parametrosensayosodu_tiempocierrevalvula1'           => new sfWidgetFormInputText(),
      'parametrosensayosodu_tiempocierrevalvula2'           => new sfWidgetFormInputText(),
      'parametrosensayosodu_tiempofinal'                    => new sfWidgetFormInputText(),
      'parametrosensayosodu_presioninicialmin'              => new sfWidgetFormInputText(),
      'parametrosensayosodu_presioninicialmax'              => new sfWidgetFormInputText(),
      'parametrosensayosodu_deltapresionestabilizacionmin'  => new sfWidgetFormInputText(),
      'parametrosensayosodu_deltapresionestabilizacionmax'  => new sfWidgetFormInputText(),
      'parametrosensayosodu_velocidadminbajatension'        => new sfWidgetFormInputText(),
      'parametrosensayosodu_deltapresionbajatensionmin'     => new sfWidgetFormInputText(),
      'parametrosensayosodu_deltapresionbajatensionmax'     => new sfWidgetFormInputText(),
      'parametrosensayosodu_deltatempmincalor'              => new sfWidgetFormInputText(),
      'parametrosensayosodu_deltatempmaxcalor'              => new sfWidgetFormInputText(),
      'parametrosensayosodu_corrientemincalor'              => new sfWidgetFormInputText(),
      'parametrosensayosodu_corrientemaxcalor'              => new sfWidgetFormInputText(),
      'parametrosensayosodu_potenciamincalor'               => new sfWidgetFormInputText(),
      'parametrosensayosodu_potenciamaxcalor'               => new sfWidgetFormInputText(),
      'parametrosensayosodu_velocidadmaxventiladorcalor'    => new sfWidgetFormInputText(),
      'parametrosensayosodu_velocidadminventiladorcalor'    => new sfWidgetFormInputText(),
      'parametrosensayosodu_presionminapagadocompresor'     => new sfWidgetFormInputText(),
      'parametrosensayosodu_deltatempminfrio'               => new sfWidgetFormInputText(),
      'parametrosensayosodu_deltatempmaxfrio'               => new sfWidgetFormInputText(),
      'parametrosensayosodu_corrientemaxfrio'               => new sfWidgetFormInputText(),
      'parametrosensayosodu_corrienteminfrio'               => new sfWidgetFormInputText(),
      'parametrosensayosodu_potenciaminfrio'                => new sfWidgetFormInputText(),
      'parametrosensayosodu_potenciamaxfrio'                => new sfWidgetFormInputText(),
      'parametrosensayosodu_velocidadminventiladorfrio'     => new sfWidgetFormInputText(),
      'parametrosensayosodu_velocidadmaxventiladorfrio'     => new sfWidgetFormInputText(),
      'parametrosensayosodu_presionminfrio'                 => new sfWidgetFormInputText(),
      'parametrosensayosodu_presionmaxfrio'                 => new sfWidgetFormInputText(),
      'parametrosensayosodu_presionmaxrecuperacion'         => new sfWidgetFormInputText(),
      'parametrosensayosodu_idversion'                      => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Versiones'), 'add_empty' => false)),
      'es_activo'                                           => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'parametrosensayosodu_id'                             => new sfValidatorChoice(array('choices' => array($this->getObject()->get('parametrosensayosodu_id')), 'empty_value' => $this->getObject()->get('parametrosensayosodu_id'), 'required' => false)),
      'parametrosensayosodu_ref'                            => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'parametrosensayosodu_descripcion'                    => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'parametrosensayosodu_modificado'                     => new sfValidatorDateTime(),
      'parametrosensayosodu_dcfs'                           => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_tiempoinicialestabilizacion'    => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_tiempomaximoestabilizacion'     => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_tiempobajatension'              => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_tiempomaximobajatension'        => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_tiempomedicioncalor'            => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_tiempomaximomedicioncalor'      => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_tiempomedicionfrio'             => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_tiemporecuperacionminima'       => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_tiempomaximorecuperacionminima' => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_delayarranquecompresor'         => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_tiempoapagadoentrecaloryfrio'   => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_tiempocierrevalvula1'           => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_tiempocierrevalvula2'           => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_tiempofinal'                    => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_presioninicialmin'              => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_presioninicialmax'              => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_deltapresionestabilizacionmin'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_deltapresionestabilizacionmax'  => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_velocidadminbajatension'        => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_deltapresionbajatensionmin'     => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_deltapresionbajatensionmax'     => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_deltatempmincalor'              => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_deltatempmaxcalor'              => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_corrientemincalor'              => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_corrientemaxcalor'              => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_potenciamincalor'               => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_potenciamaxcalor'               => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_velocidadmaxventiladorcalor'    => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_velocidadminventiladorcalor'    => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_presionminapagadocompresor'     => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_deltatempminfrio'               => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_deltatempmaxfrio'               => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_corrientemaxfrio'               => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_corrienteminfrio'               => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_potenciaminfrio'                => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_potenciamaxfrio'                => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_velocidadminventiladorfrio'     => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_velocidadmaxventiladorfrio'     => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_presionminfrio'                 => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_presionmaxfrio'                 => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_presionmaxrecuperacion'         => new sfValidatorInteger(array('required' => false)),
      'parametrosensayosodu_idversion'                      => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Versiones'))),
      'es_activo'                                           => new sfValidatorInteger(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('parametrosensayosodu[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Parametrosensayosodu';
  }

}
